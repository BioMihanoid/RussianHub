using Microsoft.AspNetCore.Mvc;
using RussianHub.Data;

namespace RussianHub.Views.VeiwComponents
{
    public class RealatedVideoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _videoDataBase;

        public RealatedVideoViewComponent(ApplicationDbContext videoDataBase)
        {
            _videoDataBase = videoDataBase;
        }

        public IViewComponentResult Invoke(Guid id)
        {
            var list = _videoDataBase.Video.ToList();
            var res = from v in list
                      where v.Id != id
                      select v;
            return View(res);
        }
    }
}
