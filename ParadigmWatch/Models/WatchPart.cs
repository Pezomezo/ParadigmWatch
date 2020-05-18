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
        public int TextureMapId { get; set; }
        [Required]
        public Texture TextureMap { get; set; }
        public int ShaderId  { get; set; }
        [Required]
        public StandardShader Shader { get; set; }
        public int TextMapId { get; set; }
        public TextMap TextMap { get; set; }
        public int WatchComponentsId { get; set; }
        public int ComponentTypeId { set; get; }
        public List<WatchComponents> WatchComponents { get; set; }
    }
}
