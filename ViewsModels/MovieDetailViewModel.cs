using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieData.Models;

namespace MovieData.ViewsModels
{
    public class MovieDetailViewModel
    {   public string Value { get;set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }

        public List<string> Genres { get; set; }
    }
}
