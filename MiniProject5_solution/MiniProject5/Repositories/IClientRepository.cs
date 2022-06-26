using MiniProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5.Repositories
{
    interface IClientRepository
    {
        List<Client> GetAllClients();
        List<Client> GetAllClientsByType(ClientType clientType);
        bool RemoveClient(int idClient);
    }
}
