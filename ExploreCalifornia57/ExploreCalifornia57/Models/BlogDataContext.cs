using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia57.Models
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Post> Posts57 { get; set; }

        public IQueryable<MonthlySpecial> MonthlySpecials
        {
            get
            {
                return new[]
                {
                    new MonthlySpecial {
                        Key = "calm",
                        Name57 = "California Calm Package",
                        Type57 = "Day Spa Package",
                        Price57 = 250,
                    },
                    new MonthlySpecial {
                        Key = "desert",
                        Name57 = "From Desert to Sea",
                        Type57 = "2 Day Salton Sea",
                        Price57 = 350,
                    },
                    new MonthlySpecial {
                        Key = "backpack",
                        Name57 = "Backpack Cali",
                        Type57 = "Big Sur Retreat",
                        Price57 = 620,
                    },
                    new MonthlySpecial {
                        Key = "taste",
                        Name57 = "Taste of California",
                        Type57 = "Tapas & Groves",
                        Price57 = 150,
                    },
                }.AsQueryable();
            }
        }

        public BlogDataContext(DbContextOptions<BlogDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
