using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RussianHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RussianHub.Models.Video> Video { get; set; }
        public DbSet<RussianHub.Models.UserRole> UserRole { get; set; }
        public DbSet<RussianHub.Models.Comment> Comment { get; set; }
        public DbSet<RussianHub.Models.Actor> Actor { get; set; }
        public DbSet<RussianHub.Models.BookMark> BookMark { get; set; }
    }
}