using Microsoft.EntityFrameworkCore;
using RussianHub.Data;
using RussianHub.Models.Entity;

namespace RussianHub.Models.Content
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PhotoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PhotoContext>>()))
            {
                // Look for any movies.
                if (context.Photo.Any())
                {
                    return;   // DB has been seeded
                }

                context.Photo.AddRange(
                    new Photo
                    {
                        Url = "http://cn13.nevsedoma.com.ua/girls/135/126738A4.jpg",
                        AltText = "porn1"
                    },

                    new Photo
                    {
                        Url = "https://i1.imageban.ru/out/2010/11/01/f6d1562f7c424737f8757596fa95b8a8.jpg",
                        AltText = "porn2"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
