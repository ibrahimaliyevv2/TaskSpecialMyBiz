﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace MyBiz.Controllers
{
	public class HomeController:Controller
	{
		public IActionResult Index()
        {
			return View();
        }
	}
}

