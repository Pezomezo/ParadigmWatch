using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class WatchPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TextureMapId { get; set; }
        public Texture TextureMap { get; set; }
        public int ShaderId  { get; set; }
        public StandardShader Shader { get; set; }
        public int TextMapId { get; set; }
        public TextMap TextMap { get; set; }
        public int WatchComponentsId { get; set; }
        public List<WatchComponents> WatchComponents { get; set; }
        public int TypeId { get; set; }
        public WatchPartType PartType { get; set; }
    }
}
