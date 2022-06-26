using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    interface ISeriesEpisodeRepository
    {
        SeriesEpisode GetSeriesEpisodeById(int idSeriesEpisode);
        SeriesEpisode CreateSeriesEpisode(SeriesEpisode episode);
        SeriesEpisode UpdateSeriesEpisode(int id, SeriesEpisode episode);
        bool RemoveSeriesEpisode(int id);
    }
}
