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

        public IActionResult Index(string watchName)
        {
            Watch returnedWatch = Repository.Watches.ToList().Where<Watch>(item => item.Name.Equals(watchName)).First();
            Console.WriteLine("CAME FROM ANOTHER VIEW: " + returnedWatch);
            return View(returnedWatch);
        }
    }
}