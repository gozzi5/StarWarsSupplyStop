using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsLibrary
{
    public class PagedListResult<T>
    {

        public List<T> Results { get; set; }

        public int Total { get; set; }

        public int Page { get; set; }
        public int Pages { get; set; }

        public void  CalculatePages() {

           
            this.Pages = (int)Math.Ceiling((decimal)Total / (decimal) Results.Count); 
        }
    }
}
