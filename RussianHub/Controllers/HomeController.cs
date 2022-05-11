using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RussianHub.Data;
using RussianHub.Models;
using System.Diagnostics;


namespace RussianHub.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly VideoContext _videoContext;

		public HomeController(ILogger<HomeController> logger, VideoContext videoContext)
		{
			_logger = logger;
			_videoContext = videoContext;
		}

		public async Task<IActionResult> Index(string serachElm)
		{
			if (serachElm != null)
            {
				var list = await _videoContext.Video.ToListAsync();
				var res = from v in list
						  where v.Genres.ToLower().Contains(serachElm.ToLower()) || v.Actors.ToLower().Contains(serachElm.ToLower()) || v.Name.ToLower().Contains(serachElm.ToLower()) || v.Description.ToLower().Contains(serachElm.ToLower())
						  select v;
				return View(res);
			}
			return View(await _videoContext.Video.ToListAsync());
		}

		public ActionResult GetCategory()
        {
			return PartialView(_videoContext.Video.ToList());
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

		public IActionResult Video(Guid id)
        {
			var list = _videoContext.Video.ToList();
			Video video = new Video();
			foreach (var obj in list)
			{
				if (obj.Id == id)
				{
					obj.CountViews++;
					_videoContext.Update(obj);
					_videoContext.SaveChanges();
					video = obj;
					break;
				}
			}
			return View(video);
        }
	}
}