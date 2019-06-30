using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExploreCalifornia57.Models
{
    public class Post
    {
        public long Id { get; set; }

        private string _key57;

        public string Key57
        {
            get
            {
                if(_key57 == null)
                {
                    _key57 = Regex.Replace(Title57.ToLower(), "[^a-z0-9]", "-");
                }
                return _key57;
            }
            set { _key57 = value; }
        }

        [Display(Name = "Post Title")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength =5,
            ErrorMessage ="Title must be between 5 and 100 characters long")]
        public string Title57 { get; set; }

        public string Author57 { get; set; }


        [Required]
        [MinLength(100, ErrorMessage = "Blog posts must be at least 100 characters long")]
        [DataType(DataType.MultilineText)]
        public string Body57 { get; set; }

        public DateTime Posted57 { get; set; }

    }
}
