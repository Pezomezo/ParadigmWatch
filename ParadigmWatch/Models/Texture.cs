using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class Texture
    {

        public int Id { get; set; }

        public string ImagePath { get; set; }

        public string TextureName { get; set; }

        public string TextureDesc { get; set; }

        public decimal TexturePrice { get; set; }
    }
}
