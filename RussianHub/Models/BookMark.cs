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

    }
}
