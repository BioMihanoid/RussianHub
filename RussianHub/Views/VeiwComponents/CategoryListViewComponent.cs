using Microsoft.AspNetCore.Mvc;
using RussianHub.Data;

namespace RussianHub.Views.VeiwComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly RussianHubContext _videoDataBase;

        public CategoryListViewComponent (RussianHubContext videoDataBase)
        {
            _videoDataBase = videoDataBase;
        }

        public IViewComponentResult Invoke()
        {
            return View(_videoDataBase.Video.ToList());
        }
    }
}
