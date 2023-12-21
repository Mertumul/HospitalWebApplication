<<<<<<< HEAD
using HospitalWebApplication.Models;
using HospitalWebApplication.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HospitalWebApplication.Interfaces;
using HospitalWebApplication.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
=======
>>>>>>> parent of 6e048cb (Patient login page has been made)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

<<<<<<< HEAD
// Database configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity configuration
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Dependency injection configuration

builder.Services.AddScoped<IDBInitializer, DbInitializer>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();

=======
>>>>>>> parent of 6e048cb (Patient login page has been made)
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
<<<<<<< HEAD
app.UseAuthentication();
=======

>>>>>>> parent of 6e048cb (Patient login page has been made)
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
<<<<<<< HEAD
    pattern: "{Area=Patient}/{controller=Home}/{action=Index}/{id?}");

// Call the data seeding method
DataSedding();
=======
    pattern: "{controller=Home}/{action=Index}/{id?}");
>>>>>>> parent of 6e048cb (Patient login page has been made)

app.Run();

// Data seeding method
void DataSedding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDBInitializer>();
        dbInitializer.Initialize();
    }
}
