using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class Backgrounds
    {
        public int Id { get; set; }
        public string BackgroundPictureFilePath { get; set; }
    }
}
