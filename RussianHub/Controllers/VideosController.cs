#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RussianHub.Data;
using RussianHub.Models;
using Xabe.FFmpeg;


namespace RussianHub.Controllers
{
    [Controller]
    public class VideosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public VideosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var videos = _context.Video.Include(p => p.Comments);
            return View(videos.ToList());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .FirstOrDefaultAsync(m => m.Id == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Link,LinkPreview,Description,Genres,Actors,Tags")] Video video)
        {
            if (ModelState.IsValid)
            {
                video.Id = Guid.NewGuid();
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Link,LinkPreview,Description,Genres,Actors,Tags")] Video video)
        {
            if (id != video.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .FirstOrDefaultAsync(m => m.Id == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var video = await _context.Video.FindAsync(id);
            _context.Video.Remove(video);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(Guid id)
        {
            return _context.Video.Any(e => e.Id == id);
        }


        [HttpPost]
        //[Route("Home/Video/{id?}", Name = "AddMark")]
        //Route["{controller=Home}/{action=Index}/{id?}"]
        public async Task<IActionResult> AddBookMark(Guid id)
        {
            Guid video = id;
            var user = await _userManager.GetUserAsync(User);
            BookMark mark;
            try
            {
                mark = await _context.BookMark.Include(p => p.User).FirstAsync(m => m.User.Id == user.Id);

            } catch (Exception ex)
            {
                mark = null;
            }


            if (mark == null)
            {
                mark = new BookMark();
            }
            mark.MarkId = new Guid();
            mark.User = user;
            var val = await _context.Video.FindAsync(id);
            if (mark.Videos == null)
                mark.Videos = new List<Video>();
            mark.Videos.Add(val);
           
            _context.BookMark.Add(mark);
            await _context.SaveChangesAsync();
            var tVideo = await _context.Video.SingleAsync(p => p.Id == id);
            tVideo.CountViews--;
            _context.Update(tVideo);
            return RedirectToAction("Video", "Videos", tVideo);
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(Guid id)
        {
            //Console.WriteLine("\nTYT -" + HttpContext.Request.HttpContext.Request.Path.Value);
            Guid video = id;
            Comment comment = new Comment();
            comment.DataPublish = DateTime.Now;
            comment.Content = Request.Form.FirstOrDefault(p => p.Key == "text").Value;
            comment.Id = Guid.NewGuid();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                comment.Name = Request.Form.FirstOrDefault(p => p.Key == "username").Value;
            else
                comment.Name = user.UserName;
            //TODO если юзер авторизован, то в это иф не заходим
            if (user == null)
                comment.Name += " (Гость)";
            comment.LinkPhotoProfile = null;
            comment.VideoId = video;
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync(true);
            var tVideo = await _context.Video.Include(p => p.Comments).SingleAsync(p => p.Id == video);
            tVideo.CountViews--;
            _context.Update(tVideo);
            await _context.SaveChangesAsync();
            //return Redirect("https://localhost:7052/Videos/Video/"+id);
            return RedirectToAction("Video", "Videos", tVideo);
        }

        public async Task<IActionResult> Video(Guid id) 
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video.Include(p => p.Comments).Include(p => p.bookMarks).SingleAsync(p => p.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            video.CountViews++;
            _context.Update(video);
            await _context.SaveChangesAsync();
            return View(video);
        }
    }
}
