﻿using Microsoft.AspNetCore.Mvc;

namespace SkeppOHoj.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
