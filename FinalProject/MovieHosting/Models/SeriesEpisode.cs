using System;
using System.Collections.Generic;

namespace MovieHosting.Models
{
    public class SeriesEpisode
    {
        public int IdSeriesEpisode { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }

        private int _idSeason;
        // Check for composition: after initial set, can't change to other Season
        public int IdSeason
        { 
            get { return _idSeason;  }
            set 
            { 
                if (_idSeason != 0) { 
                    throw new ArgumentException("composition violation");
                }
                _idSeason = value;
            } 
        }

        private SeriesSeason _seasonNavigation;
        // Check for composition: after initial set, can't change to other Season
        public virtual SeriesSeason SeasonNavigation
        {
            get { return _seasonNavigation; }
            set
            {
                if(_seasonNavigation != null)
                {
                    throw new ArgumentException("composition violation");
                }
                _seasonNavigation = value;
            }
        }

        public void ChangeData(SeriesEpisode episode)
        {
            if (episode is null)
            {
                return;
            }
            Name = episode.Name;
            Description = episode.Description;
            EpisodeNumber = episode.EpisodeNumber;
        }

        public override string ToString()
        {
            return $"{GetType()} [{IdSeriesEpisode}, {Name}]";
        }
    }
}