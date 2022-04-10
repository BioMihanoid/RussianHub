#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RussianHub.Models;

namespace RussianHub.Data
{
    public class CommentContext : DbContext
    {
        public CommentContext (DbContextOptions<CommentContext> options)
            : base(options)
        {
        }

        public DbSet<RussianHub.Models.Comment> Comment { get; set; }
    }
}
