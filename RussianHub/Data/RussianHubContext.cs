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
        public RussianHubContext (DbContextOptions<RussianHubContext> options)
            : base(options)
        {
        }

        public DbSet<RussianHub.Models.Video> Video { get; set; }
        public DbSet<RussianHub.Models.Comment> Comment { get; set; }
        public DbSet<RussianHub.Models.Actor> Actor { get; set; }
    }
}
