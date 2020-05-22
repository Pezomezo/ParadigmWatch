using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParadigmWatch.Data;
using ParadigmWatch.Infrastructure;
using ParadigmWatch.Models;
using ParadigmWatch.Models.ViewModels;

namespace ParadigmWatch.Controllers
{
    public class HomeController : Controller
    {
        ParadigmWatchContext DB;
        WatchCreator WatchCreation;
        List<WatchViewModel> Watches;
        public HomeController(ParadigmWatchContext db)
        {
            DB = db;
            WatchCreation = new WatchCreator(db);
            Watches = new List<WatchViewModel>();
        }

        [Authorize]
        public IActionResult Index()
        {
            DB.Watches.ToList().ForEach(item => Watches.Add(new WatchViewModel(item)));
            InitWatch();
            return View(Watches);
        }

        private void InitWatch()
        {
            foreach (var watch in Watches)
            {
                WatchCreation.InitWatch(watch);
            }
        }
       
    }
}