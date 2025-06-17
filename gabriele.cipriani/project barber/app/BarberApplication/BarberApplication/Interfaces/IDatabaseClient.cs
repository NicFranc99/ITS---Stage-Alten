using BarberApplication.@class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApplication.Interfaces
{
    //cambia nome dei repository
    //trasformare i metodi statici
    //non istanziare repos nei metodi ma creare la proprietà nella classe
    //
    internal interface IDatabaseClient
    {
        
        public bool CreateNewClient(Client client);
        public bool GetAllClient();
        public bool GetClientByID(int idTastiera);
        public bool DeleteClientByID(int idTastiera);
        public bool UpdateClientByID(int idTastiera, Client client);
       
    }
}
