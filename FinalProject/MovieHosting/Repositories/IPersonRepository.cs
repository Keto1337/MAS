using MovieHosting.DTO;
using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    interface IPersonRepository
    {
        List<Person> GetAllPeople();

        Person GetPersonById(int id);

        Person GetClientById(int id);

        Person GetParticipantById(int id);

        Person GetAdminById(int id);

        Person CreateClient(ClientDto client);

        Person CreateParticipant(ParticipantDto participant);

        Person CreateAdmin(PersonDto admin);

        Person UpdateClient(int id, ClientDto client);

        Person UpdateParticipant(int id, ParticipantDto participant);

        Person UpdateAdmin(int id, PersonDto admin);

        bool RemoveClient(int id);

        bool RemoveParticipant(int id);

        bool RemoveAdmin(int id);

        bool RemoveMovieParticipant(int idAdmin, int idMovieParticipant);

        bool HasPaymentMethod(int idPerson);

    }
}
