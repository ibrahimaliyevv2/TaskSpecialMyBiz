using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBiz.DAL;
using MyBiz.Helpers;
using MyBiz.Models;

namespace MyBiz.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class TeammemberController:Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _env;

        public TeammemberController(AppDbContext context, IWebHostEnvironment env)
        {
			_context = context;
			_env = env;
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

			

			teammember.ImageUrl = FileManager.Save(_env.WebRootPath, "uploads/teammembers", teammember.ImageFile);

			_context.Teammembers.Add(teammember);
			_context.SaveChanges();

			return RedirectToAction("Index");
        }

		//Sweet-Delete
		public IActionResult Delete(int id)
        {
			Teammember teammember = _context.Teammembers.FirstOrDefault(x=>x.Id==id);

			if(teammember == null)
            {
				return NotFound();
            }

			_context.Teammembers.Remove();
			_context.SaveChanges();

			
        }
	}
}

