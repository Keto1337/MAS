using MovieHosting.DTO;
using MovieHosting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Models
{
    public class Person
    {

        public int IdPerson { get; set; }

        [MinLength(2, ErrorMessage = "FirstName can't consist of less than 2 symbols")]
        public string FirstName { get; set; }
        [MinLength(2, ErrorMessage = "LastName can't consist of less than 2 symbols")]
        public string LastName { get; set; }
        public HashSet<PersonType> PersonType { get; set; }

        // Client
        public virtual List<PaymentMethod> PaymentMethods { get; set; }
        public virtual Contact ContactNavigation { get; set; }
        public virtual ICollection<ClientMovie> ClientMovies { get; set; }

        // Participant
        [MinLength(1, ErrorMessage = "Bio can't consist of less than 1 symbols")]
        public string? Bio { get; set; }

        public virtual ICollection<MovieParticipant> MovieParticipants { get; set; }

        // Admin
        public virtual ICollection<AdminMovie> AdminMovies { get; set; }

        public void ChangePersonalData(Person person)
        {
            if (person is null)
            {
                return;
            }
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        public void ChangePersonalData(PersonDto person)
        {
            if (person is null)
            {
                return;
            }
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        public void AddType(PersonType type, Person person)
        {
            if (PersonType.Contains(type))
                throw new ArgumentException("This type is already set!");

            PersonType.Add(type);
            if (person is null) return;

            if (type is Enums.PersonType.Participant)
                Bio = person.Bio;
        }

        public void RemoveType(PersonType type)
        {
            if (PersonType.Count == 1)
                throw new ArgumentException("A type cannot be removed. Person has to have at least one type");

            PersonType.Remove(type);
        }

    }
}
