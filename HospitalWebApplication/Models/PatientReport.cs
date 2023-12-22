﻿using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class PatientReport
    {
        [Key]
        public int PatientReportId {  get; set; }
        public string Diagnose { get; set; }
        public string MedicineName { get; set; }
        public ApplicationUser Patient {  get; set; }
        public ApplicationUser Doctor { get; set; }

    }
}
