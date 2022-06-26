using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1
{
    [Serializable]
    class Movie
    {
        private static int id_counter = 1;
        private readonly int movie_id;
        private string name;
        private string description;
        private double movie_cost;
        private DateTime release_date;
        private List<string> genres;
        private HashSet<Cast> actors = new HashSet<Cast>();
        private List<ClientMovie> clients = new List<ClientMovie>();

        public double Time_discount
        {
            get 
            {
                int years_from_release = DateTime.Now.Year - release_date.Year;
                double discount_percent = years_from_release switch {
                    5 => 10,
                    10 => 20,
                    15 => 30,
                    _ => 0
                };

                double cost_with_discount;
                if (discount_percent == 0)
                    cost_with_discount = movie_cost;
                else
                    cost_with_discount = discount_percent * movie_cost / 100;
                return cost_with_discount;
            }
        }

        [Required]
        public string Name { 
            get { return name; } 
            set
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field name is mandatory!");
                else name = value;
            }
        }

        [Required]
        public List<string> Genres 
        {
            get { return new List<string>(genres); }
            set
            {
                ValidateGenres(value);
                genres = value;
            }
        }

        [Required]
        public double Movie_cost { 
            get { return movie_cost; } 
            set
            {
                if (value < 0) throw new ArgumentNullException("Cost of the movie can't be lower than 0");
                else movie_cost = value;
            }
        }

        [Required]
        public DateTime Release_date 
        { 
            get { return release_date; }
            set { release_date = value; }
        }

        public HashSet<Cast> Actors { get { return new HashSet<Cast>(actors); } }

        public string Description { get { return description; } set { description = value; } }


        //constructor
        public Movie(string name, List<string> genres, DateTime release_date, string description = "", double movie_cost = 0)
        {
            movie_id = id_counter;
            id_counter++;

            Genres = genres;
            Name = name;
            Movie_cost = movie_cost;
            Description = description;
            Release_date = release_date;
        }

        //constructor overload
        public Movie(string name, List<string> genres, DateTime release_date) : this(name, genres, release_date, "", 0) { }

        public void AddGenre(string genre)
        {
            if (genre == null || genre.Trim().Length == 0) throw new ArgumentNullException("Genre can not be null or empty");
            else genres.Add(genre);
        }

        public void AddGenre(List<string> genres)
        {
            ValidateGenres(genres);
            this.genres.AddRange(genres);
        }

        public void RemoveGenre(string genre)
        {
            if (genre == null)
                throw new ArgumentNullException("Null value received! Genre can not be null");
            else if (genres.Count == 1)
                throw new Exception("One element left! Can't delete the last one.");
            else genres.Remove(genre);
        }

        private void ValidateGenres(List<string> genres)
        {
            if (genres == null || genres.Count() < 1)
                throw new ArgumentNullException("Genres list cannot be null. It should also contain at least one element");
            bool contains_nulls = genres.Any(g => g == null);
            bool contains_empty_strings = genres.Any(g => g.Trim().Length == 0);
            if (contains_nulls || contains_empty_strings) throw new ArgumentNullException("Genres list contains null or empty elements!");
        }

        public void AddCast(Cast cast)
        {
            if (cast is null) throw new ArgumentNullException("Cast can not be null!");
            if (cast.Movie != this) throw new ArgumentException("This Cast is not for this movie!");
            actors.Add(cast);
        }

        public void RemoveCast(Cast cast)
        {
            if (cast is null) throw new ArgumentNullException("Cast can not be null!");
            if (!actors.Contains(cast)) return;
            actors.Remove(cast);
            cast.RemovePair();
        }

        public void AddClient(ClientMovie client)
        {
            if (client is null) throw new ArgumentNullException("Client can not be null!");
            if (client.Movie != this) throw new ArgumentException("This Client is not for this movie!");
            clients.Add(client);
        }

        public void RemoveClient(ClientMovie client)
        {
            if (client is null) throw new ArgumentNullException("Cast can not be null!");
            if (!clients.Contains(client)) return;
            clients.Remove(client);
            client.RemovePair();
        }

    }
}
