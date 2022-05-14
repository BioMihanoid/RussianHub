#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RussianHub.Models;

namespace RussianHub.Data
{
    public class VideoContext : DbContext
    {
        public VideoContext (DbContextOptions<VideoContext> options)
            : base(options)
        {
        }

        public DbSet<RussianHub.Models.Video> Video { get; set; }
        public DbSet<RussianHub.Models.Comment> Comment { get; set; }
    }
}
