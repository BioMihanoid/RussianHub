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
        private readonly RussianHubContext _context;
        public HomeController(ILogger<HomeController> logger, RussianHubContext videoContext)
        {
            _logger = logger;
            _context = videoContext;
        }

        public async Task<IActionResult> Index(string serachElm)
        {
            var videoList = await _context.Video.ToListAsync();
            if (serachElm != null)
            {
                if (serachElm == "TopView")
                {
                    var res = from v in videoList
                              orderby v.CountViews descending
                              select v;
                    return View(res);
                }
                else if (serachElm == "NewVideo")
                {
                    var res = from v in videoList
                              orderby v.DateOFPublish descending
                              select v;
                    return View(res);
                }
                else if (serachElm == "TopRating")
                {
                    return View(videoList);
                }
                else
                {
                    var res = from v in videoList
                              where v.Genres.ToLower().Contains(serachElm.ToLower()) || v.Actors.ToLower().Contains(serachElm.ToLower()) || v.Name.ToLower().Contains(serachElm.ToLower()) || v.Description.ToLower().Contains(serachElm.ToLower())
                              select v;
                    return View(res);
                }
            }
            return View(videoList);
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

        public IActionResult Models(string searchModel)
        {
            var videoList = _context.Video.ToList();
            var modelList = _context.Actor.ToList();
            foreach (var model in modelList)
            {
                model.CountVideos = 0;
                foreach (var video in videoList)
                {
                    string[] actor = null;
                    if (video.Actors != null)
                        actor = video.Actors.Split('/');
                    if (actor != null)
                    {
                        for (int i = 0; i < actor.Length; i++)
                        {
                            if (actor[i].ToLower().Contains(model.Name.ToLower()))
                            {
                                model.CountVideos++;
                                _context.Update(model);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
            }
            if (searchModel == null)
                return View(modelList);
            else
            {
                var res = from m in modelList
                          where m.Name.ToLower().Contains(searchModel.ToLower())
                          select m;
                return View(res);
            }
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
            var videoList = _context.Video.ToList();
            Video video = new Video();
            foreach (var obj in videoList)
            {
                if (obj.Id == id)
                {
                    obj.CountViews++;
                    _context.Update(obj);
                    _context.SaveChanges();
                    video = obj;
                    break;
                }
            }
            return View(video);
        }
    }
}