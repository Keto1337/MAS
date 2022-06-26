using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    interface ISeriesSeasonRepository
    {
        SeriesSeason GetSeriesSeasonById(int idSeriesSeason);
        SeriesSeason CreateSeriesSeason(SeriesSeason season);
        SeriesSeason UpdateSeriesSeason(int id, SeriesSeason season);
        bool RemoveSeriesSeason(int id);
        LinkedList<SeriesEpisode> GetSeriesEpisodeForSeries(int idSeason);
    }
}
