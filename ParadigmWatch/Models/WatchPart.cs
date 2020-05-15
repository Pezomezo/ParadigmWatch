using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class WatchPart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Texture TextureMap { get; set; }
        [Required]
        public StandardShader Shader { get; set; }
        public TextMap TextMap { get; set; }

        public Watch Watch { get; set; }
        public string ComponentPath {get; set;}
    }
}
