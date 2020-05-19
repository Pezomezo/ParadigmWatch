using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Data;
using ParadigmWatch.Infrastructure;
using ParadigmWatch.Models;
using ParadigmWatch.Models.ViewModels;

namespace ParadigmWatch.Controllers
{
    public class ProductPageController : Controller
    {

        private ParadigmWatchContext DB;

        public ProductPageController(ParadigmWatchContext dB)
        {
            DB = dB;
        }

        public IActionResult Index(string watchName)
        {
            WatchViewModel returnedWatch = new WatchViewModel(DB.Watches.Where(watch => watch.Name.Equals(watchName)).First(), DB);
            Console.WriteLine("CAME FROM ANOTHER VIEW: " + returnedWatch);
            return View(returnedWatch);
        }
    }
}