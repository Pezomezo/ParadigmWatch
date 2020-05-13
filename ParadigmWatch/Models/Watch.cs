using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class Watch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ModelPath { get; set; }
        [Column(TypeName = "float")]
        public decimal Price { get; set; }
        public List<WatchPart> WatchComponents { get; set; }
    }
}
