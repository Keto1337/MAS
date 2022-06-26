using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5.Models
{
    class FeatureFilm : Movie
    {
        public int DurationInMins { get; set; }

        public override string ToString()
        {
            return $"{GetType()} [{IdMovie} {Name} {MovieCost} {ReleaseDate} {DurationInMins}]";
        }
    }
}
