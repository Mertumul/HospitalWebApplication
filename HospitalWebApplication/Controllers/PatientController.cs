using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApplication.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
