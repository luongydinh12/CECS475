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
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie57.Models
{
    public class Movie57
    {
        public int Id { get; set; }
        public string Title57 { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate57 { get; set; }
        public string Genre57 { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price57 { get; set; }
    }
}