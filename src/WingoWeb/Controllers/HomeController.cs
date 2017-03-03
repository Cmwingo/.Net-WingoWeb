﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WingoWeb.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WingoWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult GetRepos()
        //{
        //    var allRepos = Repo.GetRepos();
        //    return View(allRepos);
        //}

        public IActionResult GetStars()
        {
            var staredRepos = Repo.GetStars();
            return View(staredRepos);
        }
    }
}
