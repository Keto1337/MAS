using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Models
{
    public class Series : Movie
    {
        public virtual ICollection<SeriesSeason> Seasones { get; set; }

        public override string ToString()
        {
            var seasones = string.Join(", ", Seasones);

            return $"{GetType()} [{IdMovie} {Name} {MovieCost} {ReleaseDate}]";
        }

        public void ChangeData(Series series)
        {
            if (series is null)
            {
                return;
            }
            Name = series.Name;
            Description = series.Description;
            MovieCost = series.MovieCost;
            ReleaseDate = series.ReleaseDate;
            Genres = series.Genres;
        }
    }
}
