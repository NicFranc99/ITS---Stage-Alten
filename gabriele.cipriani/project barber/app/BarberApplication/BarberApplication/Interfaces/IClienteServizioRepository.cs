using BarberApplication.@class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApplication.Interfaces
{
    public interface IClienteServizioRepository
    {
        public bool AssociaServizio(Cliente_Servizio cliente_servizio);
        public bool VisualizzaServizioPerCliente(Cliente_Servizio cliente_servizio);
        public bool RemoveServizio(Cliente_Servizio cliente_servizio);
    }
}
