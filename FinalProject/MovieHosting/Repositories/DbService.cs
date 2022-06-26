using MovieHosting.DTO;
using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    public class DbService
    {

        public static List<Series> FetchSeries()
        {
            ISeriesRepository sr = new SeriesRepository();
            return sr.GetSeries();
        }

        public static Series FetchSeriesById(int idSeries) 
        {
            ISeriesRepository sr = new SeriesRepository();
            return sr.GetSeriesById(idSeries);
        }

        public static List<MovieParticipantDto> FetchMovieParticipantsById(int idSeries)
        {
            IMovieParticipantRepository mr = new MovieParticipantRepository();
            return mr.GetMovieParticipantsByIdMovie(idSeries);
        }

        public static bool DeleteMovieParticipant(int idMP)
        {
            IMovieParticipantRepository mpr = new MovieParticipantRepository();
            return mpr.RemoveMovieParticipant(idMP);
        }
    }
}
