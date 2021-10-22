using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFirstWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWeb.Context
{
    public class DbPrueba : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionBuilder.UseMySql(configuration["connectionString:ProductionDb"]);
        }

        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Curso> cursos { get; set; }
        public virtual DbSet<CourseStudent> courseStudents { get; set; }




    }
}
