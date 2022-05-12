using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RussianHub.Models;

namespace RussianHub.Data
{
    public class ActorContext : DbContext
    {
        public ActorContext (DbContextOptions<ActorContext> options)
            : base(options)
        {
        }

        public DbSet<RussianHub.Models.Actor>? Actor { get; set; }
    }
}
