using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Patient : Person
    {
        [Required(ErrorMessage = "Companion is required.")]
        public string Companion { get; set; } = null!;

        [Required(ErrorMessage = "Mother's name is required.")]
        public string MothersName { get; set; } = null!;

        [Required(ErrorMessage = "Father's name is required.")]
        public string FathersName { get; set; } = null!;

        // Navigation property
        public ICollection<Appointment> Appointments { get; set; } = null!;

        public ICollection<Prescription> Prescriptions { get; set; } = null!;
    }
}
