using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalWebApplication.Controllers
{
   
    public class PatientController : Controller
    {
        private ApplicationDbContext k = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientRegistration()
        {
            return View();

        }
    [HttpPost]
        public IActionResult PatientRegistration(Patient p)
        {
            if (ModelState.IsValid)
            {
                k.Patients.Add(p);
                k.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msj = "Hasta Eklenemedi!!!!";
                return View(p);
            }


        }
    }
}
