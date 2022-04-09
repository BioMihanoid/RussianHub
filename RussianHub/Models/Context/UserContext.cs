using Microsoft.EntityFrameworkCore;

namespace RussianHub.Models.Context;

public class UserContext : DbContext
{
    DbSet<User> User { get; set; }

    public UserContext(DbContextOptions<UserContext> option) : base(option)
    {

    }
}