using MiniProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5.Repositories
{
    class ClientRepository : IClientRepository
    {
        Context Context;
        public ClientRepository()
        {
            Context = new();
        }

        public List<Client> GetAllClients()
        {
            return Context.Clients.ToList();
        }

        public List<Client> GetAllClientsByType(ClientType clientType)
        {
            return Context.Clients.Where(cl => cl.ClientType == clientType).ToList();
        }

        public bool RemoveClient(int idClient)
        {
            var client = Context.Clients.FirstOrDefault(cl => cl.IdClient == idClient);
            if (client is null) return false;

            Context.Clients.Remove(client);
            Context.SaveChanges();
            return true;
        }
    }
}
