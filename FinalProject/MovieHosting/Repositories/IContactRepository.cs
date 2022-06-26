using MovieHosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHosting.Repositories
{
    interface IContactRepository
    {
        //bool RemoveContact(int idContact);
        List<Contact> GetContactsByClientId(int customerId);
    }
}
