using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class StandardShader
    {
        public int Id { get; set; }
        [Column(TypeName = "float")]
        
        public decimal Metalness { get; set; }
        public decimal Roughness { get; set; }
        public string NormalMapPath { get; set; }
        public decimal NormalMapIntensity { get; set; }
        public int EnvMapIntensity { set; get; }
    }
}
