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
        /*
        public DbSet<ApplicationUser> ApplicationUsers {  get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Announcement> Announcements { get; set; }s
        */
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    }
}
