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
        public virtual DbSet<Student> students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionBuilder.UseMySql(configuration["connectionString:ProductionDb"]);
        }





    }
}
