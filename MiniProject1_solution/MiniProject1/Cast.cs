using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1
{
    // ActorMovie
    [Serializable]
    class Cast
    {
        private static List<Cast> extent = new List<Cast>();

        private Movie movie;
        private Actor actor;

        private string role, actor_movie_award;
        private int salary;

        [Required]
        public Movie Movie
        {
            get { return movie; }
            private set 
            {
                if (value is null) throw new ArgumentNullException("Movie can not be equal to null");

                movie = value;
                value.AddCast(this);
            }
        }

        [Required]
        public Actor Actor
        {
            get { return actor; }
            private set 
            {
                if (value is null) throw new ArgumentNullException("Actor can not be equal to null");

                actor = value;
                value.AddCast(this);
            }
        }

        [Required]
        public string Role 
        {
            get { return role; }
            set
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field role is mandatory!");
                role = value;
            }
        }

        [Required]
        public string Actor_Movie_Reward
        {
            get { return actor_movie_award; }
            set
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field actor_movie_award is mandatory!");
                actor_movie_award = value;
            }
        }

        [Required]
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value <= 0) throw new ArgumentException("Salary can not be lower or equal to 0.");
                salary = value;
            }
        }

        public static List<Cast> Extent { get { return new List<Cast>(extent); } }
        
        // constructor
        public Cast(Movie movie, Actor actor, string role, string actor_movie_award, int salary)
        {
            if (!IsPairUnique(movie, actor)) throw new ArgumentException("Pair has to be unique!");

            Movie = movie;
            Actor = actor;

            Role = role;
            Actor_Movie_Reward = actor_movie_award;
            Salary = salary;

            extent.Add(this);
        }

        public void RemovePair()
        {
            if (movie is not null)
            {
                var tmp = movie;
                movie = null;
                tmp.RemoveCast(this);
            }

            if (actor is not null)
            {
                var tmp = actor;
                actor = null;
                tmp.RemoveCast(this);
            }

            extent.Remove(this);
        }

        private static bool IsPairUnique(Movie movie, Actor actor)
        {
            bool alreadyExists = extent.Any(cast => cast.movie == movie && cast.actor == actor);
            return !alreadyExists;
        }


    }
}
