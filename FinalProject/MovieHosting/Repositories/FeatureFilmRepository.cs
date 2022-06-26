using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    class FeatureFilmRepository : IFeatureFilmRepository
    {
        Context Context;
        public FeatureFilmRepository()
        {
            Context = new();
        }

        public FeatureFilm GetFilmById(int idSeries)
        {
            throw new NotImplementedException();
        }

        public List<FeatureFilm> GetFilms()
        {
            var films = Context.FeatureFilms.ToList();
            return films is not null ? films : new List<FeatureFilm>();
        }

        public List<FeatureFilm> GetFilmsByName(string name)
        {
            var films = Context.FeatureFilms.Where(m => m.Name.Contains(name)).ToList();
            return films is not null ? films : new List<FeatureFilm>();
        }

        public FeatureFilm CreateFeatureFilm(FeatureFilm featureFilm)
        {
            var new_featureFilm = new FeatureFilm()
            {
                Name = featureFilm.Name,
                Description = featureFilm.Description,
                MovieCost = featureFilm.MovieCost,
                ReleaseDate = featureFilm.ReleaseDate,
                Genres = featureFilm.Genres
            };
            Context.FeatureFilms.Add(new_featureFilm);
            Context.SaveChanges();
            return new_featureFilm;
        }

        public FeatureFilm UpdateFeatureFilm(int id, FeatureFilm featureFilm)
        {
            var updated = GetFilmById(id);

            if (updated is null) return null;

            updated.ChangeData(featureFilm);
            Context.SaveChanges();
            return updated;
        }

        public bool RemoveFeatureFilm(int id)
        {
            var ff = GetFilmById(id);
            if (ff is null) return false;

            Context.Remove(ff);
            Context.SaveChanges();
            return true;
        }
    }
}
