using HospitalWebApplication.Data;
using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HospitalWebApplication.Controllers
{
    [Authorize(Roles = "Doctor")]

    public class DoctorController : Controller
    {
        private readonly HospitalWebApplicationContext _context;

        public IActionResult Index()
        {
            return View();
        }
        public DoctorController(HospitalWebApplicationContext context)
        {
            _context = context;
        }
        public IActionResult ListAppointments()
        {
            // Şuanki giriş yapmış doktorun ID'sini al
            var doctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Doktorun aldığı randevuları getir
            var doctorAppointments = _context.Appointment
                .Where(appointment => appointment.DoctorId == doctorId)
                .Include(appointment => appointment.Patient) // Hasta bilgisini ekleyin
                .ToList();

            var model = new DoctorAppointmentsViewModel
            {
                SelectedDoctorAppointments = doctorAppointments
            };

            return View(model);
        }
    }
}
