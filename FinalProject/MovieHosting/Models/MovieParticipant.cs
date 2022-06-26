using MovieHosting.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieHosting.Models
{
    public class MovieParticipant
    {
        public int IdMovieParticipant { get; set; }
        public int IdParticipant { get; set; }
        public int IdMovie { get; set; }

        [MinLength(2, ErrorMessage = "MovieAward name can't consist of less than 2 symbols")]
        public string MovieAward { get; set; }
        public double MoviePayment { get; set; }
        public RoleType RoleType { get; set; }

        public virtual Person ParticipantNavigation { get; set; }
        public virtual Movie MovieNavigation { get; set; }

        public void ChangeData(MovieParticipant mp)
        {
            if (mp is null)
            {
                return;
            }
            IdParticipant = mp.IdParticipant;
            IdMovie = mp.IdMovie;
            MovieAward = mp.MovieAward;
            MoviePayment = mp.MoviePayment;
            RoleType = mp.RoleType;
        }
    }
}
