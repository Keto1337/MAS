using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Models
{
    public class SeriesSeason
    {
        public int IdSeriesSeason { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SeasonNumber { get; set; }

        private int _idSeries;

        // Check for composition: after initial set, can't change to other Series
        public int IdSeries { 
            get { return _idSeries; }
            set 
            { 
                if (_idSeries != 0)
                {
                    throw new ArgumentException("composition violation");
                }
                _idSeries = value;
            } 
        }
        private Series _seriesNavigation;
        // Check for composition: after initial set, can't change to other Series
        public virtual Series SeriesNavigation 
        {
            get { return _seriesNavigation; }
            set 
            { 
                if (_seriesNavigation is null)
                {
                    throw new ArgumentException("composition violation");
                }
                _seriesNavigation = value;
            }
        }
        public virtual ICollection<SeriesEpisode> Episodes { get; set; }

        public void ChangeData(SeriesSeason season)
        {
            if (season is null)
            {
                return;
            }
            Name = season.Name;
            Description = season.Description;
            SeasonNumber = season.SeasonNumber;
        }

        public override string ToString()
        {
            return $"{GetType()} [{IdSeriesSeason}, {Name}]";
        }
    }
}
