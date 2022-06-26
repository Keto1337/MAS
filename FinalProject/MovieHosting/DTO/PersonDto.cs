using MovieHosting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.DTO
{
    public class PersonDto
    {
        [MinLength(2, ErrorMessage = "FirstName can't consist of less than 2 symbols")]
        public string FirstName { get; set; }
        [MinLength(2, ErrorMessage = "LastName can't consist of less than 2 symbols")]
        public string LastName { get; set; }
    }
}
