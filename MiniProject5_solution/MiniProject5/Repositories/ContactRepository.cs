using MiniProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5.Repositories
{
    class ContactRepository : IContactRepository
    {
        Context Context;
        public ContactRepository()
        {
            Context = new();
        }

        public List<Contact> GetContactsByClientId(int idClient)
        {
            var client = Context.Clients.FirstOrDefault(c => c.IdClient == idClient);
            if (client is null) return null;

            List<Contact> contacts = Context.Contacts.Where(c => c.IdClient == idClient).ToList();
            return contacts;
        }

        public bool RemoveContact(int idContact)
        {
            var contact = Context.Contacts.FirstOrDefault(c => c.IdContact == idContact);
            if (contact is null) return false;

            var client = Context.Clients.FirstOrDefault(cl => cl.IdClient == contact.IdClient);
            if (client is not null)
                if (client.ContactNavigation.Count == 1)
                    throw new Exception("Can't delete last contact of the client. Please add new contacts if you want to get rid of this one.");

            Context.Contacts.Remove(contact);
            Context.SaveChanges();
            return true;
        }
    }
}
