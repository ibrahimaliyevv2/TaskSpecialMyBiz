using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyBiz.DAL;
using MyBiz.Models;

namespace MyBiz.Areas.Manage.Controllers
{
    [Area("Manage")]
	public class PositionController:Controller
	{
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

		public IActionResult Index()
        {
            var data = _context.Positions.ToList();
			return View(data);
        }


        //CRUD operations

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //This action adds position data into database
            //Here creates a transaction
            _context.Positions.Add(position);
            _context.SaveChanges(); //Acting like TCL command Commit

            return RedirectToAction("Index");
            //After sumbitting redirects to index page
        }


        public IActionResult Edit(int id)
        {
            //Takes position which we click its edit button for its id
            Position position = _context.Positions.FirstOrDefault(x=>x.Id == id);

            //If there is no such position, then send us to error page
            if (position == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            //Returns all inputs of this position with information to edit
            return View(position);
        }

        [HttpPost]
        public IActionResult Edit(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Takes position which we click its edit button for its id
            Position existPosition = _context.Positions.FirstOrDefault(x=>x.Id==position.Id);

            if(existPosition == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            //Changes its inputs to new
            existPosition.Name = position.Name;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Position position = _context.Positions.FirstOrDefault(x=>x.Id==id);

            if (position == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(position);
        }

        [HttpPost]
        public IActionResult Delete(Position position)
        {
            Position existPosition = _context.Positions.FirstOrDefault(x=>x.Id==position.Id);

            if (existPosition == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            _context.Positions.Remove(existPosition);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}

