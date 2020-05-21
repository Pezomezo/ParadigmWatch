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

namespace ParadigmWatch.Controllers.Store
{
    public class ThreeDController : Controller
    {
        private ParadigmWatchContext DB;
        WatchViewModel WatchVM;
        public ThreeDController(ParadigmWatchContext dB)
        {
            DB = dB;
        }
        public IActionResult Index(string watchName)
        {

            WatchVM = new WatchViewModel(DB.Watches.Where(watch => watch.Name.Equals(watchName)).First());
            InitWatch();
            FillUpParts();
            Console.WriteLine("CAME FROM ANOTHER VIEW: " + WatchVM);
            ViewBag.BGNames = GetaBackgrounds();
            return View(WatchVM);
        }

        private void FillUpParts()
        {
            DB.WatchParts.ToList().ForEach(part => this.WatchVM.AddPart(part));
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
            AddParts();
            AddTypes();
            FillUpShaders();
            FillUpTextures();
            FillUpTextMap();
        }


        private void AddParts()
        {
            List<WatchComponents> watchComponents = DB.RelationTableWatch.Where(item => item.WatchId == this.WatchVM.Watch.Id).ToList();

            List<WatchPart> watchParts = new List<WatchPart>();
            watchComponents.ForEach(item => watchParts.Add(DB.WatchParts.Find(item.WatchPartId)));
            watchParts.ForEach(item => this.WatchVM.Watch.AddComponent(item));
        }

        private void AddTypes()
        {
            List<WatchPartType> Types = DB.WatchPartyTypes.ToList();

            WatchVM.Watch.WatchParts.ForEach(part => part.PartType = Types.Find(type => type.Id == part.TypeId));
        }

        private void FillUpTextures()
        {
            List<Texture> Textures = DB.Textures.ToList();

            WatchVM.Watch.WatchParts.ForEach(part => part.TextureMap = Textures.Find(texture => texture.Id == part.TextureMapId));
        }
        private void FillUpShaders()
        {
            List<StandardShader> Shaders = DB.StandardShaders.ToList();

            WatchVM.Watch.WatchParts.ForEach(part => part.Shader = Shaders.Find(shader => shader.Id == part.ShaderId));
        }
        private void FillUpTextMap()
        {
            List<TextMap> Texts = DB.TextMaps.ToList();

            WatchVM.Watch.WatchParts.ForEach(part => part.TextMap = Texts.Find(text => text.Id == part.TextMapId));
        }
    }
}