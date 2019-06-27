/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie57.Models
{
    public class SeedData57
    {
    }
}*/

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie57.Models
{
    public static class SeedData57
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovie57Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovie57Context>>()))
            {
                // Look for any movies.
                if (context.Movie57.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie57.AddRange(
                    new Movie57
                    {
                        Title57 = "When Harry Met Sally",
                        ReleaseDate57 = DateTime.Parse("1989-2-12"),
                        Genre57 = "Romantic Comedy",
                        Price57 = 7.99M
                    },

                    new Movie57
                    {
                        Title57 = "Ghostbusters ",
                        ReleaseDate57 = DateTime.Parse("1984-3-13"),
                        Genre57 = "Comedy",
                        Price57 = 8.99M
                    },

                    new Movie57
                    {
                        Title57 = "Ghostbusters 2",
                        ReleaseDate57 = DateTime.Parse("1986-2-23"),
                        Genre57 = "Comedy",
                        Price57 = 9.99M
                    },

                    new Movie57
                    {
                        Title57 = "Rio Bravo",
                        ReleaseDate57 = DateTime.Parse("1959-4-15"),
                        Genre57 = "Western",
                        Price57 = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
