using HospitalWebApplication.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Policlinic
    {
        [Key]
        public int PoliclinicId { get; set; }

        [Required(ErrorMessage = "Policlinic name is required.")]
        public string PoliclinicName { get; set; } = null!;

        // Foreign key
        public int DepartmentId { get; set; }

        // Navigation property
        public Department Department { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = null!;

    }
}
