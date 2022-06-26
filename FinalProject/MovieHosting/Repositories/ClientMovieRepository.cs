using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    public class ClientMovieRepository : IClientMovieRepository
    {
        private Context Context;
        private ClientMovieRepository()
        {
            Context = new Context();
        }

        public ClientMovie GetClientMovieById(int idClient, int idMovie)
        {
            return Context.ClientMovies.FirstOrDefault(cm => cm.IdClient == idClient && cm.IdMovie == idMovie);
        }

        public ClientMovie CreateClientMovie(ClientMovie clientMovie)
        {
            // (SUBSET)
            // Client has to have at least one payment method to buy a movie
            IPersonRepository pr = new PersonRepository();
            var haspaymentMethod = pr.HasPaymentMethod(clientMovie.IdClient);
            if (!haspaymentMethod)
            {
                return null;
            }

            var newClientMovie = new ClientMovie
            {
                IdClient = clientMovie.IdClient,
                IdMovie = clientMovie.IdMovie,
                PurchaseDate = clientMovie.PurchaseDate
            };

            Context.ClientMovies.Add(newClientMovie);
            Context.SaveChanges();
            return newClientMovie;
        }

        
        public bool RemoveClientMovie(int idClient, int idMovie)
        {
            var clientMovie = GetClientMovieById(idClient, idMovie);
            if (clientMovie is null)
            {
                return false;
            }

            Context.ClientMovies.Remove(clientMovie);
            Context.SaveChanges();
            return true;
        }

        
        public ClientMovie UpdateClientMovie(int idClient, int idMovie, ClientMovie clientMovie)
        {
            var editedClientMovie = GetClientMovieById(idClient, idMovie);
            if (editedClientMovie is null)
            {
                return null;
            }

            editedClientMovie.PurchaseDate = clientMovie.PurchaseDate;
            Context.SaveChanges();
            return editedClientMovie;
        }
    }
}
