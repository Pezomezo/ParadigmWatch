using Microsoft.AspNetCore.Mvc;
using ParadigmWatch.Data;
using ParadigmWatch.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Components
{
    public class YouMayAlsoLikeViewComponent : ViewComponent
    {
        string watchName;
        private ParadigmWatchContext DB;

        public YouMayAlsoLikeViewComponent(ParadigmWatchContext dB)
        {
            DB = dB;
        }

        public IViewComponentResult Invoke(string watchName)
        {
            this.watchName = watchName;
            var listOfOtherWatches = DB.Watches.Where(item => !item.Name.Equals(this.watchName));
            return View(listOfOtherWatches);
        }
    }
}
