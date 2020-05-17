using Microsoft.AspNetCore.Mvc;
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

        public IViewComponentResult Invoke(string watchName)
        {
            this.watchName = watchName;
            var listOfOtherWatches = Repository.Watches.Where(item => !item.Name.Equals(this.watchName));
            return View(listOfOtherWatches);
        }
    }
}
