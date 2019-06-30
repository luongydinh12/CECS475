using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia57.Models
{
    public class FormattingService
    {
        public string AsReadableDate(DateTime date57)
        {
            return date57.ToString("D");
        }
    }
}
