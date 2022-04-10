#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RussianHub.Models.Entity;

namespace RussianHub.Data
{
    public class PhotoContext : DbContext
    {
        public PhotoContext (DbContextOptions<PhotoContext> options)
            : base(options)
        {
        }

        public DbSet<RussianHub.Models.Entity.Photo> Photo { get; set; }
    }
}
