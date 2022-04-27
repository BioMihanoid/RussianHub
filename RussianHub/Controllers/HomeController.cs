using Microsoft.AspNetCore.Mvc;
using RussianHub.Models;
using System.Diagnostics;

namespace RussianHub.Controllers
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

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Bookmarks()
		{
			return View();
		}

		public IActionResult Models()
		{
			return View();
		}

		public IActionResult Photos()
		{
			return View();
		}

		public IActionResult Admin()
		{
			return View();
		}

		public IActionResult Gifs()
		{
			return View();
		}

		public IActionResult Blog()
		{
			return View();
		}

		public IActionResult TermsOfUse()
        {
			return View();
        }
	}
}