using Microsoft.AspNetCore.Mvc;
using RussianHub.Data;

namespace RussianHub.Views.VeiwComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _videoDataBase;

        public CategoryListViewComponent (ApplicationDbContext videoDataBase)
        {
            _videoDataBase = videoDataBase;
        }

        public IViewComponentResult Invoke()
        {
            return View(_videoDataBase.Video.ToList());
        }
    }
}
