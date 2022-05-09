using Microsoft.AspNetCore.Mvc;
using RussianHub.Data;

namespace RussianHub.Views.VeiwComponents
{
    public class RealatedVideoViewComponent : ViewComponent
    {
        private readonly VideoContext _videoDataBase;

        public RealatedVideoViewComponent(VideoContext videoDataBase)
        {
            _videoDataBase = videoDataBase;
        }

        public IViewComponentResult Invoke()
        {
            //TODO add logic choose video
            return View(_videoDataBase.Video.ToList());
        }
    }
}
