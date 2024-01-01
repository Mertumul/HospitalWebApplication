using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApplication.Controllers
{
	public class PanelController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
