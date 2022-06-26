using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System;

namespace MiniProject5.Models
{
    class Contact
    {

        public int IdContact { get; set; }
        [Email]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public int IdClient { get; set; }

        private Client client_navigation;
        public virtual Client ClientNavigation 
        {
            get => client_navigation;
            set
            {
                if (client_navigation is not null)
                {
                    if (value != client_navigation)
                        throw new ArgumentException("Can't reassign a client.");
                }
                client_navigation = value;

            }

        }
        
    }
}