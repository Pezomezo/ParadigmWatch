using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Models;
using ParadigmWatch.Infrastructure;
using ParadigmWatch.Data;
using ParadigmWatch.Models.ViewModels;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ParadigmWatch.Controllers.Store
{
    public class ThreeDController : Controller
    {

        private WatchCreator creator;
        private ParadigmWatchContext DB;
        WatchViewModel WatchVM;
        public ThreeDController(ParadigmWatchContext dB)
        {
            DB = dB;
        }

        public IActionResult Index(string watchId)
        {

            WatchVM = new WatchViewModel(DB.Watches.Where(watch => watch.Id.Equals(int.Parse(watchId))).First());
            InitWatch();
            FillUpParts();
            WatchVM.fillWatch();



            System.IO.File.WriteAllText("./wwwroot/js/WatchPartsJSON.js", JsonConvert.SerializeObject(WatchVM.WatchInitModel, Formatting.Indented));
            Console.WriteLine("CAME FROM ANOTHER VIEW: " + WatchVM);
            ViewBag.BGNames = GetaBackgrounds();
            
            return View(WatchVM);
        }

        private void FillUpParts()
        {
            DB.WatchParts.ToList().ForEach(part => this.WatchVM.AddPart(part));
            AddTypes();
        }



        private IEnumerable<SelectListItem> GetaBackgrounds()
        {
            List<SelectListItem> countryList = new List<SelectListItem>();
            List<string> BGNames = new List<string>();
            foreach (var item in DB.Backgrounds.ToList())
            {
                if (BGNames.Count == 0)
                {
                    BGNames.Add(item.BackgroundName);
                }
                else
                {
                    if (!item.BackgroundName.Equals(BGNames.Last()))
                    {
                        BGNames.Add(item.BackgroundName);
                    }
                }
            }

            foreach (var item in BGNames)
            {
                countryList.Add(new SelectListItem { Text = item });
            }

            return countryList;
        }

        private void InitWatch()
        {
            creator = new WatchCreator(DB);
            creator.InitWatch(WatchVM.Watch);
            //AddParts();
            //FillUpShaders();
            //FillUpTextures();
            //FillUpTextMap();
        }

        private void AddTypes()
        {
            List<WatchPartType> Types = DB.WatchPartyTypes.ToList();

            WatchVM.AllParts.ForEach(part => part.PartType = Types.Find(type => type.Id == part.TypeId));
        }
    }
}