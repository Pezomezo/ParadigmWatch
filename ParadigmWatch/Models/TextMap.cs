using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class TextMap
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
    }
}
