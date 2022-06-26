using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    interface IFeatureFilmRepository
    {
        List<FeatureFilm> GetFilmsByName(string name);
        List<FeatureFilm> GetFilms();
        FeatureFilm GetFilmById(int idSeries);
        FeatureFilm CreateFeatureFilm(FeatureFilm featureFilm);
        FeatureFilm UpdateFeatureFilm(int id, FeatureFilm featureFilm);
        bool RemoveFeatureFilm(int id);
    }
}
