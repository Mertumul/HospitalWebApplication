using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Identity;
namespace HospitalWebApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender {  get; set; }
        public string Address { get; set; }
        public DateTime DOB {  get; set; }
        public string Specialist { get; set; }
        public bool IsDoctor { get; set; }
        public Department? Department { get; set; }
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }
        [NotMapped]
        public ICollection<PatientReport> PatientReports { get; set; }
                                                                        
    }
}

namespace HospitalWebApplication.Models
{
    public enum Gender
    {
    Male,Female,Other
    }
}