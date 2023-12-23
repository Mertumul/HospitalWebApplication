using HospitalWebApplication.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks; // Eklenen isim alanı

namespace HospitalWebApplication.Areas.Identity.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Patient.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Doctor.ToString()));


            var user = new ApplicationUser
            {
                UserName = "b201210049@sakarya.edu.tr",
                Email = "b201210049@sakarya.edu.tr",
                FirstName = "Mert",
                LastName = "Umul",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Sau123,");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }
    }
}
