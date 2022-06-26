using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Models
{
    public class FeatureFilm : Movie
    {
        public int DurationInMins { get; set; }

        public override string ToString()
        {
            return $"{GetType()} [{IdMovie} {Name} {MovieCost} {ReleaseDate} {DurationInMins}]";
        }

        public void ChangeData(FeatureFilm featureFilm)
        {
            if (featureFilm is null)
            {
                return;
            }
            Name = featureFilm.Name;
            Description = featureFilm.Description;
            MovieCost = featureFilm.MovieCost;
            ReleaseDate = featureFilm.ReleaseDate;
            Genres = featureFilm.Genres;
        }
    }
}
