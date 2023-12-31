using System;
using System.Collections.Generic;
using HospitalWebApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalWebApplication.Models
{
    public class DoctorAppointmentsViewModel
    {
        public DateTime SelectedDate { get; set; }
        public int SelectedDepartment { get; set; }
        public string SelectedDoctorId { get; set; }
        public string SelectedDoctorName { get; set; } // Yeni eklenen özellik
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<ApplicationUser> Doctors { get; set; }
        public IEnumerable<Appointment> SelectedDoctorAppointments { get; set; }
    }
}
