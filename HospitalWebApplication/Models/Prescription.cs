using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [ForeignKey("Patient")]
        [Required(ErrorMessage = "Patient ID is required.")]
        public int PatientId { get; set; }
        [ForeignKey("Doctor")]
        [Required(ErrorMessage = "Doctor ID is required.")]
        public int DoctorId { get; set; }
        public string MedicineName { get; set; } = null!;

        // Navigation property
        public Person Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;

    }
}
