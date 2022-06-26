using System;

namespace MovieHosting.Models
{
    public class MovieOfWeek
    {
        public int IdMovieOfWeek { get; set; }
        public DateTime StartDate { get; set; }
        public int IdMovie { get; set; }

        public virtual Movie MovieNavigation { get; set; }
    }
}
