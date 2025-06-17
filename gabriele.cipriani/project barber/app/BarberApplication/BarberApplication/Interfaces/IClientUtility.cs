using BarberApplication.@class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApplication.Interfaces
{
    public  interface IClientUtility
    {
        public void CreateClient(Client cliente);
        public bool DeleteClient(int id);
        public void GetAllClients();
        public bool GetClientsByID(int id);
        public bool UpdateClientsByID(int id, Client cliente);
    }
}
