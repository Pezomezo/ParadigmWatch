using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models.ViewModels
{
    public class WatchInitModel
    {


        public string ModelPath { set; get; }
        public int WatchPartId { set; get; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string TextureImagePath { get; set; }
        public decimal Metalness { get; set; }
        public string NormalMapPath { get; set; }
        public decimal NormalMapIntensity { get; set; }
        public decimal Roughness { get; set; }
        public decimal EnvMapInt { get; set; }
        public string Type { set; get; }
        public bool isSelected { set; get; }
    }
}
