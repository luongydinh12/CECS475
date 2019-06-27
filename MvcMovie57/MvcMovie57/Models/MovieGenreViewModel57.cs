/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie57.Models
{
    public class MovieGenreViewModel57
    {
    }
}
*/

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie57.Models
{
    public class MovieGenreViewModel57
    {
        public List<Movie57> Movies57 { get; set; }
        public SelectList Genres57 { get; set; }
        public string MovieGenre57 { get; set; }
        public string SearchString57 { get; set; }
    }
}