using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        // Navigation property
        public ICollection<ApplicationUser> Employees { get; set; }
    }
}
