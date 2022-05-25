using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RussianHub.Models
{
    public class BookMark
    {
        [Required, Key]
        public Guid MarkId { get; set; }
        public IdentityUser User { get; set; }
        public List<Video> Videos { get; set; }

        public BookMark()
        {
            Videos = new List<Video>();

            MarkId = Guid.NewGuid();
            User = new IdentityUser();
            Videos = new List<Video>();
            Videos.Add(new Video());
        }
    }
}
