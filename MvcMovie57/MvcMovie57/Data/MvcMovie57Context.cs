using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie57.Models
{
    public class MvcMovie57Context : DbContext
    {
        public MvcMovie57Context (DbContextOptions<MvcMovie57Context> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie57.Models.Movie57> Movie57 { get; set; }
    }
}
