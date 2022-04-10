using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RussianHub.Data;
using RussianHub.Models;
using System.Diagnostics;
using RussianHub.Models.Entity;

namespace RussianHub.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly PhotoContext _context;

		public HomeController(ILogger<HomeController> logger, PhotoContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		
		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Registration()
		{
			return View();
		}

		public IActionResult Bookmarks()
		{
			return View();
		}
		
		public IActionResult Models()
		{
			return View();
		}

		public async Task<IActionResult> Photos()
		{
            return View(await _context.Photo.ToListAsync());
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
		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}