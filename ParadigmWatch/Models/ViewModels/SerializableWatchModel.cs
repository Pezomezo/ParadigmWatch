using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models.ViewModels
{
    public class SerializableWatchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WatchImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
