using HospitalWebApplication.Constants;
using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HospitalWebApplication.Areas.Identity.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            //Seed Roles
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Patient.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Doctor.ToString()));

            // Check if the user with the specified email exists
            var userInDb = await userManager.FindByEmailAsync("b201210049@sakarya.edu.tr");

            if (userInDb == null)
            {
                // Create a new Department if it doesn't exist
                var department = new Department { DepartmentName = "Management" };

                // Create a new user with the specified details
                var newUser = new ApplicationUser
                {
                    UserName = "b201210049@sakarya.edu.tr",
                    Email = "b201210049@sakarya.edu.tr",
                    FirstName = "Mert",
                    LastName = "Umul",
                    Address = "Sakarya",
                    Specialist = "Manager",
                    Gender = Gender.Male,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    // Do not set AppUserDepartmentId here
                };

                // Create the user
                var result = await userManager.CreateAsync(newUser, "Sau123,");

                if (result.Succeeded)
                {
                    // Assign the user to the Admin role
                    await userManager.AddToRoleAsync(newUser, Roles.Admin.ToString());

                    // Assign the user to the Department
                    newUser.Department = department;

                    // Update the user to save the changes
                    await userManager.UpdateAsync(newUser);
                }
            }
        }
    }
}
