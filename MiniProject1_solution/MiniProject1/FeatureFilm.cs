using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1
{
    [Serializable]
    class FeatureFilm : Movie
    {
        private static int minimum_duration_mins = 60;

        public static int Minimum_duration_mins { 
            get { return minimum_duration_mins; }
            set 
            {
                if (value <= 0) throw new ArgumentNullException("Innapropriate argument value was provided. Value has to be greater than 0!");
                else minimum_duration_mins = value;
            }
        }

        //constructor
        public FeatureFilm(string name, List<string> genres, DateTime release_date, string description = null) : base(name, genres, release_date, description)
        {
        }
    }
}
