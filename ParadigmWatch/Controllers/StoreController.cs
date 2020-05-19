using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Data;
using ParadigmWatch.Infrastructure;
using ParadigmWatch.Models.ViewModels;

namespace ParadigmWatch.Controllers
{
    public class StoreController : Controller
    {

        ParadigmWatchContext DB;
        List<WatchViewModel> Watches;

        public StoreController(ParadigmWatchContext db)
        {
            DB = db;
            Watches = new List<WatchViewModel>();
        }

        public IActionResult Index()
        {
            DB.Watches.ToList().ForEach(item => Watches.Add(new WatchViewModel(item, DB)));
            return View(Watches);
        }
    }
}