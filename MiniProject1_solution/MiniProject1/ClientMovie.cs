using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1
{
    class ClientMovie
    {

        private static List<ClientMovie> extent = new List<ClientMovie>();

        private Movie movie;
        private Client client;


        public ClientMovie(Movie movie, Client client)
        {
            if (!IsPairUnique(movie, client)) throw new ArgumentException("Pair has to be unique!");

            this.movie = movie;
            this.client = client;

            extent.Add(this);
        }

        public Movie Movie
        {
            get { return movie; }
            private set
            {
                if (value is null) throw new ArgumentNullException("Movie can not be equal to null");

                movie = value;
                value.AddClient(this);
            }
        }

        public Client Client
        {
            get { return client; }
            private set
            {
                if (value is null) throw new ArgumentNullException("Client can not be equal to null");

                client = value;
                value.AddMovie(this);
            }
        }

        public void RemovePair()
        {
            if (movie is not null)
            {
                var tmp = movie;
                movie = null;
                tmp.RemoveClient(this);
            }

            if (client is not null)
            {
                var tmp = client;
                client = null;
                tmp.RemoveMovie(this);
            }

            extent.Remove(this);
        }

        private static bool IsPairUnique(Movie movie, Client client)
        {
            bool alreadyExists = extent.Any(cast => cast.movie == movie && cast.client == client);
            return !alreadyExists;
        }
    }
}
