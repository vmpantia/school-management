﻿using Microsoft.AspNetCore.Mvc;
using SM.Web.Models;
using System.Diagnostics;

namespace SM.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}