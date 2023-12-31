using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalWebApplication.Areas.Identity.Data;

namespace HospitalWebApplication.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }

        [ForeignKey("Patient")]
        public string? PatientId { get; set; } // Nullable olarak güncellendi
        public ApplicationUser? Patient { get; set; } // Nullable olarak güncellendi

        [ForeignKey("Doctor")]
        public string? DoctorId { get; set; } // Nullable olarak güncellendi
        public ApplicationUser? Doctor { get; set; } // Nullable olarak güncellendi
    }
}
