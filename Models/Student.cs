using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWeb.Models
{
    [Table("estudiante")]
    public class Student
    {
        [Key]
        public int id { get; set; }
       
        [Display(Name = "Id estudiante")]
        public int id_estudiantil { get; set; }
        public string nombre { get; set; }
        public int grado { get; set; }
        public string jornada { get; set; }


    }
}
