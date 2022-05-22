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
        private readonly RussianHubContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public VideosController(RussianHubContext context, UserManager<IdentityUser> userManager)
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

        [Route("Home/Video/{id?}")]
        [HttpPost]
        public async Task<IActionResult> AddComment()
        {
            Console.WriteLine("\nTYT -" + HttpContext.Request.HttpContext.Request.Path.Value);
            Guid video;
            {
                string str = HttpContext.Request.HttpContext.Request.Path.Value;
                str = str.Substring(str.Length - "d2ae069c-a202-4a25-9618-267c2168c08b".Length);
                video = Guid.Parse(str);
            }
            Comment comment = new Comment();
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
            return RedirectToAction();
        }

        public static void QwaTest(Comment video)
        {

            Console.WriteLine();
            Console.WriteLine(video);
        }
    }
}
