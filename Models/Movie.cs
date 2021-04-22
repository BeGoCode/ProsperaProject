using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAndMoviesApp.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public float ImdbRating { get; set; }
    }
}
