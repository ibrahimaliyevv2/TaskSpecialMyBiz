using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBiz.DAL;
using MyBiz.Models;

namespace MyBiz.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class TeammemberController:Controller
	{
		private readonly AppDbContext _context;

        public TeammemberController(AppDbContext context)
        {
			_context = context;
        }

		public IActionResult Index()
        {
			var data = _context.Teammembers.ToList();
			return View(data);
        }

		//CRUD operations

		public IActionResult Create()
        {
			
			return View();
        }

		[HttpPost]
		public IActionResult Create(Teammember teammember)
		{

			if (teammember.ImageFile != null) {

				if (teammember.ImageFile.ContentType != "image/png" && teammember.ImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "File format should be image/png or image/jpeg.");
					return View();
				}

				if (teammember.ImageFile.Length > 2097152)
				{
					ModelState.AddModelError("ImageFile", "File should be less than 2 MB.");
					return View();
				}
			}

            else
            {
				ModelState.AddModelError("ImageFile", "ImageFile is required");
            }

			if (!ModelState.IsValid)
			{
				return View();
			}

			string path = @"/Users/ibrahimaliyevv/Projects/TaskSpecialMyBiz/MyBiz/MyBiz/wwwroot/uploads/teammembers/" + teammember.ImageFile.FileName;

			using(FileStream stream = new FileStream(path, FileMode.Create))
            {
				teammember.ImageFile.CopyTo(stream);
			}
			
			teammember.ImageUrl = teammember.ImageFile.FileName;

			_context.Teammembers.Add(teammember);
			_context.SaveChanges();

			return RedirectToAction("Index");
        }
	}
}

