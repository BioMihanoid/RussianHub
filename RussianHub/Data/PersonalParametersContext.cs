#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RussianHub.Models;

namespace RussianHub.Data
{
    public class PersonalParametersContext : DbContext
    {
        public PersonalParametersContext (DbContextOptions<PersonalParametersContext> options)
            : base(options)
        {
        }

        public DbSet<RussianHub.Models.PersonalParameters> PersonalParameters { get; set; }
    }
}
