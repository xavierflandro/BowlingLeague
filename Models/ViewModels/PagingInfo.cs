using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class PagingInfo
    {

        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        //  Calculate number of pages
        public int NumPages => (int) Math.Ceiling((decimal) TotalNumItems / ItemsPerPage);
    }
}
