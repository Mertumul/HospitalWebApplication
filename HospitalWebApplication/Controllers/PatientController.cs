using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HospitalWebApplication.Controllers
{
   
    public class PatientController : Controller
    {
        private ApplicationDbContext k = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        //Registration
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
        public IActionResult Login()
        {
            return View();
        }

        //Login
    [HttpPost]
        public async Task<IActionResult> Login(Patient p)
        {
            var informations = k.Patients.FirstOrDefault(x => x.TCIdentificationNo == p.TCIdentificationNo && x.Password == p.Password);
            if (informations != null)
            {
                var claims = new List<Claim>();
                {
                    new Claim(ClaimTypes.Name, p.TCIdentificationNo);
                };
                var useridentity = new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");

        }
    }
}
