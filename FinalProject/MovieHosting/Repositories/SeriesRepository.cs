using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    class SeriesRepository : ISeriesRepository
    {
        Context Context;
        public SeriesRepository()
        {
            Context = new();
        }

        public List<Series> GetSeriesByName(string name)
        {
            var series = Context.Seriess.Where(m => m.Name.Contains(name)).ToList();
            return series is not null ? series : new List<Series>();
        }

        public List<Series> GetSeries()
        {
            var series = Context.Seriess.ToList();
            return series is not null ? series : new List<Series>();
        }

        public Series GetSeriesById(int idSeries)
        {
            var series = Context.Seriess.FirstOrDefault(sr => sr.IdMovie == idSeries);
            return series is not null ? series : throw new ArgumentException("Incorrect IdMovie provided");
        }

        public Series CreateSeries(Series series)
        {
            var new_series = new Series()
            {
                Name = series.Name,
                Description = series.Description,
                MovieCost = series.MovieCost,
                ReleaseDate = series.ReleaseDate,
                Genres = series.Genres
            };
            Context.Seriess.Add(new_series);
            Context.SaveChanges();
            return new_series;
        }

        public Series UpdateSeries(int id, Series series)
        {
            var updated = GetSeriesById(id);

            if (updated is null) return null;

            updated.ChangeData(series);
            Context.SaveChanges();
            return updated;
        }

        public bool RemoveSeries(int id)
        {
            var s = GetSeriesById(id);
            if (s is null) return false;

            ISeriesSeasonRepository ssr = new SeriesSeasonRepository();
            foreach (var ss in s.Seasones)
            {
                ssr.RemoveSeriesSeason(ss.IdSeriesSeason);
            }

            Context.Remove(s);
            Context.SaveChanges();
            return true;
        }

        public LinkedList<SeriesSeason> GetSeriesSeasonsForSeries(int idSeries)
        {
            var seasons = new LinkedList<SeriesSeason>((from ss in Context.SeriesSeasons
                                                        where ss.IdSeries == idSeries
                                                        orderby ss.SeasonNumber ascending
                                                        select ss).ToList());

            return seasons is not null ? seasons : new LinkedList<SeriesSeason>();
        }

    }
}
