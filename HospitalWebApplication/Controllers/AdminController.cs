using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HospitalWebApplication.Models;
using HospitalWebApplication.Areas.Identity.Data;
using HospitalWebApplication.Data;

namespace HospitalWebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly HospitalWebApplicationContext _context;

        public AdminController(HospitalWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }
    }
}
