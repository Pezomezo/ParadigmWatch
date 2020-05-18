using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class WatchComponents
    {
        public int Id { get; set; }
        public int WatchId { get; set; }
        public Watch Watch { get; set; }
        public string watchComponentPath { set; get; }
        public int WatchPartId { get; set; }
        public WatchPart WatchPart { get; set; }
    }
}
