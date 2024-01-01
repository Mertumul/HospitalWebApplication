using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
		public IActionResult About()
		{
			return View();
		}
		public IActionResult Services()
		{
			return View();
		}
		public IActionResult News()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}
	}
}