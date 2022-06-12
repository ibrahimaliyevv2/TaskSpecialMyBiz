using System;
using Microsoft.AspNetCore.Mvc;

namespace MyBiz.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class DashboardController:Controller
	{
		public IActionResult Index()
        {
			return View();
        }

		public IActionResult Error()
        {
			return View();
        }
	}
}

