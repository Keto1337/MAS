using MovieHosting.DTO;
using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        Context Context;
        public MovieRepository()
        {
            Context = new();
        }

        public Movie GetMovieById(int idMovie)
        {
            var movie = Context.Movies.FirstOrDefault(m => m.IdMovie == idMovie);
            return movie;
        }
    }
}
