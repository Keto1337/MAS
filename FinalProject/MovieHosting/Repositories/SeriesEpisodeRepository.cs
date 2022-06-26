using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    class SeriesEpisodeRepository : ISeriesEpisodeRepository
    {
        Context Context;
        public SeriesEpisodeRepository()
        {
            Context = new();
        }

        public SeriesEpisode GetSeriesEpisodeById(int idSeriesEpisode)
        {
            var episode = Context.SeriesEpisodes.FirstOrDefault(sr => sr.IdSeriesEpisode == idSeriesEpisode);
            return episode is not null ? episode : throw new ArgumentException("Incorrect IdSeriesEpisode provided");
        }

        public SeriesEpisode CreateSeriesEpisode(SeriesEpisode episode)
        {
            var season = Context.SeriesSeasons.FirstOrDefault(s => s.IdSeriesSeason == episode.IdSeason);
            if (season is null) throw new ArgumentException("Season does not exist.");

            var new_episode = new SeriesEpisode()
            {
                Name = episode.Name,
                Description = episode.Description,
                EpisodeNumber = episode.EpisodeNumber,
                IdSeason = episode.IdSeason
            };
            Context.SeriesEpisodes.Add(new_episode);
            Context.SaveChanges();
            return new_episode;
        }

        public SeriesEpisode UpdateSeriesEpisode(int id, SeriesEpisode episode)
        {
            var updated = GetSeriesEpisodeById(id);

            if (updated is null) return null;

            updated.ChangeData(episode);
            Context.SaveChanges();
            return updated;
        }


        public bool RemoveSeriesEpisode(int id)
        {
            var se = GetSeriesEpisodeById(id);
            if (se is null) return false;

            Context.Remove(se);
            Context.SaveChanges();
            return true;
        }
    }
}
