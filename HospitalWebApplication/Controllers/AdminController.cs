using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HospitalWebApplication.Models;
using HospitalWebApplication.Areas.Identity.Data;
using HospitalWebApplication.Data;
using HospitalWebApplication.Services;

namespace HospitalWebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly HospitalWebApplicationContext _context;
        private readonly IUserAccessor _userAccessor;

        public AdminController(HospitalWebApplicationContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult addDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }
        public IActionResult addAppointment()
        {
            // Oluşturulan randevuları veritabanına kaydet
            _context.Appointment.AddRange(GenerateAppointments());
            _context.SaveChanges();

            // Başarılı bir şekilde randevular oluşturulduğunda yönlendirme yapabilirsiniz
            return View();
        }

        public List<Appointment> GenerateAppointments()
        {
            const int appointmentDurationInMinutes = 15;
            const int maxAppointmentsPerDay = 28;
            const int startHour = 9;
            const int endHour = 17;

            List<Appointment> appointments = new List<Appointment>(maxAppointmentsPerDay * _context.Users.Count(u => u.IsDoctor));
            var allDoctors = _context.Users.Where(u => u.IsDoctor).ToList();

            DateTime currentDate = DateTime.Today;
            DateTime startDateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, startHour, 0, 0);

            // O gün için mevcut randevuları kontrol et
            var existingAppointments = _context.Appointment
                .Where(a => a.Date >= startDateTime && a.Date < startDateTime.AddDays(1).Date)
                .ToList();

            foreach (var doctor in allDoctors)
            {
                // Doktor bazında daha önce eklenmiş bir randevu kontrolü
                bool isExistingDoctorAppointment = existingAppointments.Any(a => a.DoctorId == doctor.Id);

                if (!isExistingDoctorAppointment)
                {
                    for (int hour = startHour; hour < endHour; hour++)
                    {
                        for (int minute = 0; minute < 60; minute += appointmentDurationInMinutes)
                        {
                            DateTime appointmentDateTime = startDateTime.AddHours(hour).AddMinutes(minute);

                            // Randevu oluştur
                            appointments.Add(new Appointment
                            {
                                Date = appointmentDateTime,
                                Status = false,
                                DoctorId = doctor.Id
                            });

                            // Oluşturulan randevuyu mevcut randevular listesine ekle
                            existingAppointments.Add(new Appointment
                            {
                                Date = appointmentDateTime,
                                Status = false,
                                DoctorId = doctor.Id
                            });
                        }
                    }
                }
            }

            return appointments;
        }



    }

}

