using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ParadigmWatch.Models.ViewModels
{
    public class ThreeDViewModel
    {
        public Watch Watch { get; set; }
        public List<Backgrounds> Backgrounds { get; set; }
    }
}
