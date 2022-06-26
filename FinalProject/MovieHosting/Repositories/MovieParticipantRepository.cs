using MovieHosting.DTO;
using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    class MovieParticipantRepository : IMovieParticipantRepository
    {
        Context Context;
        public MovieParticipantRepository()
        {
            Context = new();
        }

        public MovieParticipant GetMovieParticipantById(int idMovieParticipant)
        {
            var mp = Context.MovieParticipants.FirstOrDefault(mp => mp.IdMovieParticipant == idMovieParticipant);
            return mp is not null ? mp : throw new ArgumentException("Incorrect IdMovieParticipant provided");
        }

        public MovieParticipant CreateMovieParticipant(MovieParticipant mp)
        {
            var movie = Context.Movies.FirstOrDefault(m => m.IdMovie == mp.IdMovie);
            if (movie is null) throw new ArgumentException("Movie does not exist.");

            var participant = Context.Persons.FirstOrDefault(p => p.IdPerson == mp.IdParticipant);
            if (participant is null) throw new ArgumentException("Participant does not exist.");

            var new_mp = new MovieParticipant()
            {
                IdParticipant = mp.IdParticipant,
                IdMovie = mp.IdMovie,
                MovieAward = mp.MovieAward,
                MoviePayment = mp.MoviePayment,
                RoleType = mp.RoleType
            };
            Context.MovieParticipants.Add(new_mp);
            Context.SaveChanges();
            return new_mp;
        }

        public MovieParticipant UpdateMovieParticipant(int id, MovieParticipant mp)
        {
            var updated = GetMovieParticipantById(id);

            if (updated is null) return null;

            updated.ChangeData(mp);
            Context.SaveChanges();
            return updated;
        }

        public bool RemoveMovieParticipant(int idMP)
        {
            var mp = GetMovieParticipantById(idMP);
            if (mp is null) return false;

            Context.Remove(mp);
            Context.SaveChanges();
            return true;
        }

        public List<MovieParticipantDto> GetMovieParticipantsByIdMovie(int idMovie)
        {
            var mps = (from mp in Context.MovieParticipants
                       join p in Context.Persons on mp.IdParticipant equals p.IdPerson
                       where mp.IdMovie == idMovie
                       select new
                       {
                           IdMovieParticipant = mp.IdMovieParticipant,
                           FullName = $"{p.FirstName} {p.LastName}",
                           RoleType = mp.RoleType
                       }).ToList();

            if (mps is null || mps.Count() == 0) return new();

            List<MovieParticipantDto> dtos = new();
            foreach (var mp in mps)
            {
                dtos.Add(new()
                {
                    IdMovieParticipant = mp.IdMovieParticipant,
                    FullName = mp.FullName,
                    RoleType = mp.RoleType
                });
            }

            return dtos;
        }
    }
}
