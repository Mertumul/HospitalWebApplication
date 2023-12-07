using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        public string DepartmentName { get; set; } = null!;

        // Navigation property
        public ICollection<Policlinic> Polyclinics { get; set; } = null!;
    }
}
