using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProject1
{
    [Serializable]
    class Series : Movie
    {
        private HashSet<SeriesEpisode> episodes = new HashSet<SeriesEpisode>();

        public HashSet<SeriesEpisode> Episodes { get { return new HashSet<SeriesEpisode>(episodes); } }

        //constructor
        public Series(string name, List<string> genres, DateTime release_date, string description = "")
            : base(name, genres, release_date, description) { }

        public void AddEpisode(SeriesEpisode episode)
        {
            if (episode == null) throw new ArgumentNullException("Null value received! Episode can not be null");
            if (episodes.Contains(episode)) return;

            episodes.Add(episode);
            episode.Series = this;
        }

        public void RemoveEpisode(SeriesEpisode episode)
        {
            if (episode == null) throw new ArgumentNullException("Null value received! Episode can not be null");
            if (!episodes.Contains(episode)) return;

            episodes.Remove(episode);
            episode.Series = null;
        }

        public void DeleteAllEpisodes()
        {
            if (episodes.Count == 0) return; // no exception because the `Whole` object can be deleted even without any episodes

            episodes.ToList().ForEach(ep =>
                {
                    ep.Series = null;
                    episodes.Remove(ep);
                });
        }

        public override string ToString()
        {
            return $"{this.GetType()} [ name: {Name}; episodes: {episodes} ]";
        }
    }
}
