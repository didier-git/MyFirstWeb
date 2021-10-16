using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWeb.Models
{
    [Table("curso")]
    public class Curso
    {
        [Key]
        public int id { get; set; }
        public int grado { get; set; }
        public int aforo { get; set; }
        public string descripcion { get; set; }
        public string directorPrograma { get; set; }
    }
}
