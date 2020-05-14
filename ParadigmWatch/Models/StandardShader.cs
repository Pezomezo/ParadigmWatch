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
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "float")]
        public decimal Metalness { get; set; }
        [Column(TypeName = "float")]
        public decimal Roughness { get; set; }
        public string NormalMapPath { get; set; }
        [Column(TypeName = "float")]
        public decimal NormalMapIntensity { get; set; }
    }
}
