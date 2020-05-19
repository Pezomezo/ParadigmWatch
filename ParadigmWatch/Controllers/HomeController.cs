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
        List<WatchViewModel> Watches;
        public HomeController(ParadigmWatchContext db)
        {
            DB = db;
            Watches = new List<WatchViewModel>();
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            DB.Watches.ToList().ForEach(item => Watches.Add( new WatchViewModel(item, DB)));
            return View(Watches);
        }
    }
}