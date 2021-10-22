using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWeb.Models
{
    [Table("cursoestudiante")]
    public class CourseStudent
    {
        [Key]
        public int id { get; set; }
        public int curso { get; set; }
        public int estudiante { get; set; }
    }
}
