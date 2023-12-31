using HospitalWebApplication.Areas.Identity.Data;
using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalWebApplication.Data
{
    public class HospitalWebApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalWebApplicationContext(DbContextOptions<HospitalWebApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            builder.ApplyConfiguration(new DepartmentEntityConfiguration());
            builder.ApplyConfiguration(new AppointmentEntityConfiguration());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HospitalWebApplication.Models.Appointment>? Appointment { get; set; }

    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
            builder.Property(u => u.Address).HasMaxLength(255);
            builder.Property(u => u.Gender).HasConversion<string>();
            builder.Property(u => u.Specialist).HasMaxLength(255);

            // Configure Department relationship
            builder.HasOne(u => u.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(u => u.AppUserDepartmentId)
                .OnDelete(DeleteBehavior.SetNull); // Use Restrict or another suitable action

        }
    }
}

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        // Configure properties
        builder.Property(d => d.DepartmentName).HasMaxLength(255).IsRequired();

        // Configure Employees relationshipkodu ya
        builder.HasMany(d => d.Employees)
            .WithOne(u => u.Department)
            .HasForeignKey(u => u.AppUserDepartmentId) // Specify the foreign key property
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class AppointmentEntityConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        // Configure properties
        builder.Property(a => a.Date).IsRequired();
        builder.Property(a => a.Status).IsRequired();

        // Configure Patient relationship
        builder.HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed

        // Configure Doctor relationship
        builder.HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed
    }
}
