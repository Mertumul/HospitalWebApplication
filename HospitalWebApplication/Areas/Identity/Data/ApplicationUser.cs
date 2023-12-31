using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace HospitalWebApplication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the HospitalWebApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }

    public Gender Gender { get; set; }
    public string Address { get; set; }
    public DateTime DOB { get; set; }
    public string Specialist { get; set; }
    public bool IsDoctor { get; set; }

    [ForeignKey("Department")]
    public int? AppUserDepartmentId { get; set; } // Make DepartmentId nullable
    public Department? Department { get; set; }

    [NotMapped]
    public List <Appointment> Appointments { get; set; }
}
public enum Gender
{
    Male, Female, Other
}

