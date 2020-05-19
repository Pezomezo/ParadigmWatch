using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class Discounts
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public int DiscountAmount { get; set; }

    }
}
