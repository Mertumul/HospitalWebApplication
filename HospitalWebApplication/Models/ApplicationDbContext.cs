using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HospitalWebApplication.Models

{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Hospital;Username=postgres;Password=postgres");
        }





    }
}
