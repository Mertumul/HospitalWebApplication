using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApplication.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [ForeignKey("Patient")]
        [Required(ErrorMessage = "Patient ID is required.")]
        public int PatientId { get; set; }

        [ForeignKey("Doctor")]
        [Required(ErrorMessage = "Doctor ID is required.")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Appointment date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Appointment time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }


        [Required(ErrorMessage = "Complaint is required.")]
        public string Complaint { get; set; } = null!;

        public bool AppointmentStatus { get; set; }

        public bool DrStatus { get; set; }

        // Navigation property
        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
    }
}
