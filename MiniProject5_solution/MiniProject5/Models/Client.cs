using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5.Models
{
    class Client
    {

        public int IdClient { get; set; }
        [MinLength(3)]
        public string FirstName { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }
        [MinLength(3)]
        public string? Bio { get; set; }

        public ClientType ClientType { get; set; }

        public virtual ICollection<Contact> ContactNavigation { get; set; }
        public virtual ICollection<ClientMovie> ClientMovies { get; set; }

        public Client()
        {
            ClientMovies = new HashSet<ClientMovie>();
        }
    }
}
