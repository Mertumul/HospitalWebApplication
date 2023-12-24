using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospitalWebApplication.Areas.Identity.Data;

namespace HospitalWebApplication.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        // Navigation property
        public List<ApplicationUser> Employees { get; set; }
    }
}
