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
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Hospital1;Username=postgres;Password=postgres");
        }





    }
}
