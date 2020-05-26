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
        WatchCreator WatchCreation;
        WatchViewModel WatchVM;

        public ProductPageController(ParadigmWatchContext db)
        {
            DB = db;
            WatchCreation = new WatchCreator(db);
        }

        public IActionResult Index(int watchId)
        {
            WatchVM = new WatchViewModel(DB.Watches.Where(watch => watch.Id.Equals(watchId)).First());

            WatchCreation.InitWatch(WatchVM.Watch);
            Console.WriteLine("CAME FROM ANOTHER VIEW: " + WatchVM);
            return View(WatchVM);
        }
        
    }
}