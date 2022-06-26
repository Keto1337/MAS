using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5.Models
{
    abstract class Movie
    {
        public int IdMovie { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double MovieCost { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<ClientMovie> ClientMovies { get; set; } = new HashSet<ClientMovie>();

        public override string ToString()
        {
            return $"{GetType()} [{IdMovie} {Name} {MovieCost} {ReleaseDate}]";
        }
    }
}
