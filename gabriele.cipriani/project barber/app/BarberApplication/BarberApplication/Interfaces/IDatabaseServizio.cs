using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApplication.Interfaces
{
    internal interface IDatabaseServizio
    {
        public bool CreateNewServizio(Servizio servizio);
        public bool GetAllServizi();
        public bool GetServizioByID(int idServizio);
        public bool DeleteServizioByID(int idServizio);
        public bool UpdateServizioByID(int idServizio, Servizio servizio);
    }
}
