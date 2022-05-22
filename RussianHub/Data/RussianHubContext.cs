#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RussianHub.Models;

namespace RussianHub.Data
{
    public class RussianHubContext : DbContext
    {
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Video)
                .WithMany(b => b.Comments);
        }
        */
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Video)
                .WithMany(b => b.Comments)
                .HasForeignKey(p => p.VideoId);
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Video)
                .WithMany(b => b.Comments)
                .HasForeignKey(p => p.VideoId);

        }
        public RussianHubContext (DbContextOptions<RussianHubContext> options)
            : base(options)
        {
        }

        public DbSet<RussianHub.Models.Video> Video { get; set; }
        public DbSet<RussianHub.Models.Comment> Comment { get; set; }
        public DbSet<RussianHub.Models.Actor> Actor { get; set; }
    }
}
