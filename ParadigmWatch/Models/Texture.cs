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
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        [MaxLength(50)]
        public string TextureName { get; set; }
        [Required]
        [MaxLength(150)]
        public string TextureDesc { get; set; }
        [Required]
        [Column(TypeName = "float")]
        public decimal TexturePrice { get; set; }
    }
}
