using MovieHosting.DTO;
using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    interface IMovieParticipantRepository
    {
        MovieParticipant GetMovieParticipantById(int idMovieParticipant);
        MovieParticipant CreateMovieParticipant(MovieParticipant mp);
        MovieParticipant UpdateMovieParticipant(int id, MovieParticipant mp);
        bool RemoveMovieParticipant(int idMP);
        List<MovieParticipantDto> GetMovieParticipantsByIdMovie(int idMovie);
    }
}
