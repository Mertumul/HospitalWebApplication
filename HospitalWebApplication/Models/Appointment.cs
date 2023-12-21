using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApplication.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Complaint { get; set; } = null!;

        public ApplicationUser Patient { get; set; }

        public ApplicationUser Doctor { get; set; }
    }
}
