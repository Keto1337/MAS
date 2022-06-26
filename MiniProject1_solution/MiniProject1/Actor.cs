using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1
{
    [Serializable]
    class Actor
    {

        private string first_name;
        private string last_name;
        private string bio;
        private HashSet<Cast> movies = new HashSet<Cast>();

        [Required]
        public string FirstName
        {
            get { return first_name; }
            set
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field first name is mandatory!");
                else first_name = value;
            }
        }

        [Required]
        public string LastName
        {
            get { return last_name; }
            set
            {
                if (value == null || value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. Field last name is mandatory!");
                else last_name = value;
            }
        }

        public string Bio
        {
            get { return bio; }
            set
            {
                if (value is not null)
                    if (value.Trim().Length == 0) throw new ArgumentNullException("Empty field specified. String argument can't be empty");

                bio = value;
            }
        }

        public HashSet<Cast> Movies { get { return new HashSet<Cast>(movies); } }

        // constructor
        public Actor(string firstName, string lastName, string bio = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
        }

        public void AddCast(Cast cast)
        {
            if (cast is null) throw new ArgumentNullException("Cast can not be null!");
            if (cast.Actor != this) throw new ArgumentException("This Cast is not for this actor!");
            movies.Add(cast);
        }

        public void RemoveCast(Cast cast)
        {
            if (cast is null) throw new ArgumentNullException("Cast can not be null!");
            if (!movies.Contains(cast)) return;
            movies.Remove(cast);
            cast.RemovePair();
        }

    }
}
