using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Models;
using ParadigmWatch.Infrastructure;
using ParadigmWatch.Data;
using ParadigmWatch.Models.ViewModels;

namespace ParadigmWatch.Controllers.Store
{
    public class ThreeDController : Controller
    {
        

        private ParadigmWatchContext DB;

        public ThreeDController(ParadigmWatchContext dB)
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