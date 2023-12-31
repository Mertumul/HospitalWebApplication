﻿using HospitalWebApplication.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalWebApplication.Models;
using HospitalWebApplication.Areas.Identity.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebApplication.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private readonly HospitalWebApplicationContext _context;

        public PatientController(HospitalWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SelectDate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectDate(DateTime selectedDate)
        {
            var allDepartments = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(allDepartments, "DepartmentId", "DepartmentName");

            return View("SelectDepartment", new DoctorAppointmentsViewModel
            {
                SelectedDate = selectedDate,
                Departments = new SelectList(allDepartments, "DepartmentId", "DepartmentName")
            });
        }

        [HttpPost]
        public IActionResult SelectDepartment(DateTime selectedDate, int selectedDepartmentId)
        {
            var allDepartments = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(allDepartments, "DepartmentId", "DepartmentName");

            return RedirectToAction("SelectDoctor", new DoctorAppointmentsViewModel
            {
                SelectedDate = selectedDate,
                SelectedDepartment = selectedDepartmentId
            });
        }
        public IActionResult SelectDoctor(DoctorAppointmentsViewModel model)
        {
            int selectedDepartmentId = model.SelectedDepartment;
            DateTime selectedDate = model.SelectedDate;

            // Seçilen departmana ait doktorları ve sadece doktor olanları getir
            var selectedDepartmentDoctors = _context.Users
                .Where(user => user.AppUserDepartmentId == selectedDepartmentId && user.IsDoctor)
                .ToList();

            // ViewModel'i doldur
            model.Doctors = selectedDepartmentDoctors.Select(doctor => new ApplicationUser
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                // Diğer doktor özelliklerini ekleyebilirsiniz
            });
            return View(model);
        }

        public IActionResult SelectedDoctorAppointments(DoctorAppointmentsViewModel model)
        {
            string selectedDoctorId = model.SelectedDoctorId;

            // Seçilen doktora ait tüm randevuları getir
            var selectedDoctorAppointments = _context.Appointment
                .Where(appointment => appointment.DoctorId == selectedDoctorId)
                .ToList();

            // ViewModel'i doldur
            model.SelectedDoctorAppointments = selectedDoctorAppointments;

            return View(model);
        }
        [HttpPost]
        public IActionResult TakeAppointment(int appointmentId)
        {
            // Şuanki giriş yapmış kullanıcının ID'sini al
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // İlgili randevuyu veritabanında bulun
            var appointment = _context.Appointment.FirstOrDefault(a => a.Id == appointmentId);

            if (appointment != null && !appointment.Status)
            {
                // Kullanıcının ID'sini randevuya ekle
                appointment.PatientId = currentUserId;

                // Randevunun durumunu "Busy" olarak güncelle
                appointment.Status = true;

                // Veritabanını güncelle
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Appointment successfully taken!";
            }

            return RedirectToAction("SelectedDoctorAppointments", new { selectedDoctorId = appointment.DoctorId });
        }

        public IActionResult ListAppointments()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var userAppointments = _context.Appointment
                .Where(appointment => appointment.PatientId == userId)
                .Include(appointment => appointment.Doctor) // Doktor bilgisini ekleyin
                .ToList();

            var model = new DoctorAppointmentsViewModel
            {
                SelectedDoctorAppointments = userAppointments
            };

            return View(model);
        }




    }



}

