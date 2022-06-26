using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5.Models
{
    class Series : Movie
    {
        public virtual ICollection<SeriesEpisode> Episodes { get; set; } = new HashSet<SeriesEpisode>();

        public override string ToString()
        {
            var episodes = string.Join(", ", Episodes);

            return $"{GetType()} [{IdMovie} {Name} {MovieCost} {ReleaseDate}] and its Episodes:\n {episodes}";
        }
    }
}
