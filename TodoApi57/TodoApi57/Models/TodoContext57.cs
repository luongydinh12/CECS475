/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi57.Models
{
    public class TodoContext57
    {
    }
}*/

using Microsoft.EntityFrameworkCore;

namespace TodoApi57.Models
{
    public class TodoContext57 : DbContext
    {
        public TodoContext57(DbContextOptions<TodoContext57> options)
            : base(options)
        {
        }

        public DbSet<TodoItem57> TodoItems57 { get; set; }
    }
}