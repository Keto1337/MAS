using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System;

namespace MovieHosting.Models
{
    public class Contact
    {

        public int IdContact { get; set; }

        [Email]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public int IdClient { get; set; }

        public virtual Person ClientNavigation { get; set; }

    }
}