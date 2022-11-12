using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIMovies.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }

        public List<object> Movies { get; set; }
    }

}