/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie57.Models
{
    public class Movie_57
    {
    }
}*/
using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie57.Models
{
    public class Movie57
    {
        public int Id { get; set; }
        public string Title57 { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate57 { get; set; }
        public string Genre57 { get; set; }
        public decimal Price57 { get; set; }
    }
}