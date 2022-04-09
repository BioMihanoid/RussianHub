using Microsoft.EntityFrameworkCore;

namespace RussianHub.Models;

public class TestContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public TestContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=test.db");
    }
}