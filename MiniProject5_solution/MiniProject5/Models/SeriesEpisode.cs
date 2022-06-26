using System.Collections.Generic;

namespace MiniProject5.Models
{
    class SeriesEpisode
    {
        private static ICollection<SeriesEpisode> extent = new HashSet<SeriesEpisode>();

        public int IdSeriesEpisode { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int IdSeries { get; set; }
        public Series SeriesNavigation { get; set; }

        public override string ToString()
        {
            return $"{GetType()} [{IdSeriesEpisode}, {Name}]";
        }
    }
}