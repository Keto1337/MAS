using Microsoft.EntityFrameworkCore;
using MovieHosting.DTO;
using MovieHosting.Enums;
using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    class PersonRepository : IPersonRepository
    {
        Context Context;
        public PersonRepository()
        {
            Context = new();
        }

        public Person GetPersonById(int id)
        {
            return Context.Persons.Where(p => p.IdPerson == id).FirstOrDefault();
        }

        // Read

        public Person GetClientById(int id)
        {
            var client = Context.Persons.Where(p => p.IdPerson == id).FirstOrDefault();
            if (!client.PersonType.Contains(PersonType.Client))
            {
                return null;
            }
            return client;
        }

        public Person GetParticipantById(int id)
        {
            var participant = Context.Persons.Where(p => p.IdPerson == id).FirstOrDefault();
            if (!participant.PersonType.Contains(PersonType.Participant))
            {
                return null;
            }
            return participant;
        }

        public Person GetAdminById(int id)
        {
            var admin = Context.Persons.Where(p => p.IdPerson == id).FirstOrDefault();
            if (!admin.PersonType.Contains(PersonType.Admin))
            {
                return null;
            }
            return admin;
        }


        public List<Person> GetAllPeople()
        {
            return Context.Persons.ToList();
        }

        // Create

        public Person CreateClient(ClientDto client)
        {
            var new_client = new Person();
            new_client.ChangePersonalData(client);
            new_client.PersonType = new() { PersonType.Client };

            Context.Persons.Add(new_client);
            Context.SaveChanges();
            return new_client;
        }

        public Person CreateParticipant(ParticipantDto participant)
        {
            var new_participant = new Person();
            new_participant.ChangePersonalData(participant);
            new_participant.PersonType = new() { PersonType.Participant };
            new_participant.Bio = participant.Bio;

            Context.Persons.Add(new_participant);
            Context.SaveChanges();
            return new_participant;
        }

        public Person CreateAdmin(PersonDto admin)
        {
            var new_admin = new Person();
            new_admin.ChangePersonalData(admin);
            new_admin.PersonType = new() { PersonType.Admin };

            Context.Persons.Add(new_admin);
            Context.SaveChanges();
            return new_admin;
        }

        // Update

        public Person UpdateClient(int id, ClientDto client)
        {
            var updated = GetClientById(id);

            if (updated is null) return null;

            updated.ChangePersonalData(client);
            Context.SaveChanges();
            return updated;
        }

        public Person UpdateParticipant(int id, ParticipantDto participant)
        {
            var updated = GetParticipantById(id);

            if (updated is null) return null;

            updated.ChangePersonalData(participant);
            Context.SaveChanges();
            return updated;
        }

        public Person UpdateAdmin(int id, PersonDto admin)
        {
            var updated = GetAdminById(id);

            if (updated is null) return null;

            updated.ChangePersonalData(admin);
            Context.SaveChanges();
            return updated;
        }

        // Delete

        public bool RemoveClient(int id)
        {
            var cl = GetClientById(id);
            if (cl is null) return false;

            Context.Remove(cl);
            Context.SaveChanges();
            return true;
        }

        public bool RemoveParticipant(int id)
        {
            var part = GetParticipantById(id);
            if (part is null) return false;

            Context.Remove(part);
            Context.SaveChanges();
            return true;
        }

        public bool RemoveAdmin(int id)
        {
            var admin = GetAdminById(id);
            if (admin is null) return false;

            Context.Remove(admin);
            Context.SaveChanges();
            return true;
        }

        // returns true if person has at least one payment method
        public bool HasPaymentMethod(int idPerson)
        {
            var person = Context.Persons.AsNoTracking().Include(p => p.PaymentMethods).Where(p => p.IdPerson == idPerson).FirstOrDefault();
            if (person is null) return false;
            
            return person.PaymentMethods.Count != 0;
        }

        public bool RemoveMovieParticipant(int idAdmin, int idMovieParticipant)
        {
            var admin = GetAdminById(idAdmin);
            if (admin is null) return false;

            var mp = Context.MovieParticipants.FirstOrDefault(mp => mp.IdMovieParticipant == idMovieParticipant);
            if (mp is null) return false;

            var hasAccess = admin.AdminMovies.Any(am => am.IdMovie == mp.IdMovie);
            if (!hasAccess) return false;

            Context.MovieParticipants.Remove(mp);
            Context.SaveChanges();
            return false;
        }

    }
}
