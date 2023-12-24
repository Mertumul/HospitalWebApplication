using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApplication.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
