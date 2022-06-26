using MovieHosting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.DTO
{
    public class MovieParticipantDto
    {
        public int IdMovieParticipant { get; set; }
        public string FullName { get; set; }
        public RoleType RoleType { get; set; }
    }
}
