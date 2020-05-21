using ParadigmWatch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models.ViewModels
{
    public class WatchViewModel
    {

        public Watch Watch { get; set; }
        public List<WatchPart> AllParts { get; set; } = new List<WatchPart>();
        public WatchViewModel(Watch watch)
        {
            Watch = watch;

        }

        public void AddPart(WatchPart part)
        {
            this.AllParts.Add(part);
        }
    }
}
