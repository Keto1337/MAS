using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.DTO
{
    public class ParticipantDto : PersonDto
    {
        // [0..1]
        public string? Bio { get; set; }
    }
}
