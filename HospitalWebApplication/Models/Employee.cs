using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApplication.Models
{
    public class Employee : Person
    {

        [Required(ErrorMessage = "Policlinic ID is required.")]
        [ForeignKey("Policlinic")]
        public int PoliclinicId { get; set; }
        // Navigation property
        public Policlinic Policlinic { get; set; } = null!;

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Doctor status is required.")]
        public bool IsDoctor { get; set; }

        [Required(ErrorMessage = "Staff status is required.")]
        public bool IsStaff { get; set; }

        [Required(ErrorMessage = "Secretary status is required.")]
        public bool IsSecretary { get; set; }

        [Required(ErrorMessage = "Criminal record is required.")]
        public int CriminalRecord { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public int Salary { get; set; }


    }
}
