using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HospitalWebApplication.Models

{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers {  get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Reports { get; set; }
        public DbSet<PatientReport> Appointments { get; set; }


    }
}
