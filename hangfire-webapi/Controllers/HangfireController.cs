using Microsoft.AspNetCore.Mvc;

namespace hangfire_webapi.Controllers
{
	public class HangfireController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
