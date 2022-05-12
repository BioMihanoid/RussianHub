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
        private readonly ActorContext _actorContext;
        public HomeController(ILogger<HomeController> logger, VideoContext videoContext, ActorContext actorContext)
        {
            _logger = logger;
            _videoContext = videoContext;
            _actorContext = actorContext;
        }

        public async Task<IActionResult> Index(string serachElm)
        {
            var videoList = await _videoContext.Video.ToListAsync();
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
            var videoList = _videoContext.Video.ToList();
            var modelList = _actorContext.Actor.ToList();
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
                                _actorContext.Update(model);
                                _actorContext.SaveChanges();
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
            var videoList = _videoContext.Video.ToList();
            Video video = new Video();
            foreach (var obj in videoList)
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