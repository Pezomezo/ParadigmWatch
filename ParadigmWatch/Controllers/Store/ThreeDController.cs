using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Models;
using ParadigmWatch.Infrastructure;

namespace ParadigmWatch.Controllers.Store
{
    public class ThreeDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}