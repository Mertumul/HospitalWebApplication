using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalWebApplication.Areas.Identity.Data;

namespace HospitalWebApplication.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public ApplicationUser Patient { get; set; }

        public ApplicationUser Doctor { get; set; }
    }
}
