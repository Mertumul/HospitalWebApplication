using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApplication.Models
{
    public class Doctor 
    {
        [Key]
        public int DoctorId { get; set; }


        [Required(ErrorMessage = "Policlinic ID is required.")]
        [ForeignKey("Policlinic")]
        public int PoliclinicId { get; set; }
        // Navigation property
        public Policlinic Policlinic { get; set; } = null!;

        [Required(ErrorMessage = "TC Identification Number is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Identification Number must be 11 characters.")]
        public string TCIdentificationNo { get; set; } = null!;

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; } = null!;


        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Gender must be a single character.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]
        public short Age { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Doctor title is required.")]
        public string DrTitle { get; set; } = null!;

        [Required(ErrorMessage = "Doctor telephone is required.")]
        public string DrTelephone { get; set; } = null!;

        [Required(ErrorMessage = "Doctor email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string DrEmail { get; set; } = null!;

        [Required(ErrorMessage = "Criminal record is required.")]
        public int CriminalRecord { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Doctor experience is required.")]
        public short DrExperience { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }



        public ICollection<Prescription> Prescriptions { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = null!;


    }
}
