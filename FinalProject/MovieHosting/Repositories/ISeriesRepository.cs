using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    interface ISeriesRepository
    {
        List<Series> GetSeriesByName(string name);
        List<Series> GetSeries();
        Series GetSeriesById(int idSeries);
        Series CreateSeries(Series series);
        Series UpdateSeries(int id, Series series);
        bool RemoveSeries(int id);
        LinkedList<SeriesSeason> GetSeriesSeasonsForSeries(int idSeries);
    }
}
