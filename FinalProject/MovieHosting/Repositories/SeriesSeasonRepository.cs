using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    class SeriesSeasonRepository : ISeriesSeasonRepository
    {
        Context Context;
        public SeriesSeasonRepository()
        {
            Context = new();
        }

        public SeriesSeason GetSeriesSeasonById(int idSeriesSeason)
        {
            var season = Context.SeriesSeasons.FirstOrDefault(sr => sr.IdSeriesSeason == idSeriesSeason);
            return season is not null ? season : throw new ArgumentException("Incorrect IdSeriesSeason provided");
        }

        public SeriesSeason CreateSeriesSeason(SeriesSeason season)
        {
            var series = Context.Seriess.FirstOrDefault(s => s.IdMovie == season.IdSeries);
            if (series is null) throw new ArgumentException("Series does not exist.");

            var new_season = new SeriesSeason()
            {
                Name = season.Name,
                Description = season.Description,
                SeasonNumber = season.SeasonNumber,
                IdSeries = season.IdSeries
            };
            Context.SeriesSeasons.Add(new_season);
            Context.SaveChanges();
            return new_season;
        }

        public SeriesSeason UpdateSeriesSeason(int id, SeriesSeason season)
        {
            var updated = GetSeriesSeasonById(id);

            if (updated is null) return null;

            updated.ChangeData(season);
            Context.SaveChanges();
            return updated;
        }

        public bool RemoveSeriesSeason(int id)
        {
            var ss = GetSeriesSeasonById(id);
            if (ss is null) return false;

            ISeriesEpisodeRepository ssr = new SeriesEpisodeRepository();
            foreach (var se in ss.Episodes)
            {
                ssr.RemoveSeriesEpisode(se.IdSeriesEpisode);
            }

            Context.Remove(ss);
            Context.SaveChanges();
            return true;
        }

        public LinkedList<SeriesEpisode> GetSeriesEpisodeForSeries(int idSeason)
        {
            var episodes = new LinkedList<SeriesEpisode>((from ss in Context.SeriesEpisodes
                                                         where ss.IdSeason == idSeason
                                                        orderby ss.EpisodeNumber ascending
                                                        select ss).ToList());

            return episodes is not null ? episodes : new LinkedList<SeriesEpisode>();
        }
    }
}
