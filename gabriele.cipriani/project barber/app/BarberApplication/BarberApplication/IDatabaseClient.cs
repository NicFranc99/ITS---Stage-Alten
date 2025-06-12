using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApplication
{
    internal interface IDatabaseClient
    {
        
        public bool CreateNewClient(Client client);
        public bool GetAllClient();
        public bool GetClientByID(int idTastiera);
        public bool DeleteClientByID(int idTastiera);
        //public bool UpdateClientByID();
    }
}
