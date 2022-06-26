using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    public interface IClientMovieRepository
    {
        ClientMovie UpdateClientMovie(int idClient, int idMovie, ClientMovie clientMovie);
        ClientMovie CreateClientMovie(ClientMovie clientMovie);
        bool RemoveClientMovie(int idClient, int idMovie);
        ClientMovie GetClientMovieById(int idClient, int idMovie);
    }
}
