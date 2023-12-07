using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Doctor : Employee
    {
        [Required(ErrorMessage = "Doctor title is required.")]
        public string DrTitle { get; set; } = null!;

        [Required(ErrorMessage = "Doctor address is required.")]
        public string DrAddress { get; set; } = null!;

        [Required(ErrorMessage = "Doctor telephone is required.")]
        public string DrTelephone { get; set; } = null!;

        [Required(ErrorMessage = "Doctor experience is required.")]
        public short DrExperience { get; set; }

        [Required(ErrorMessage = "Doctor email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string DrEmail { get; set; } = null!;

        public ICollection<Prescription> Prescriptions { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = null!;


    }
}
