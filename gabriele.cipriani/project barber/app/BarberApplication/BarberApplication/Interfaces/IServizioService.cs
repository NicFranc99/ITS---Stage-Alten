using BarberApplication.@class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApplication.Interfaces
{
    public interface IServizioService
    {
        public void CreateServizio(Servizio servizio);
        public bool DeleteServizio(int id);
        public void GetAllServizio();
        public bool GetServizioByID(int id);
        public bool UpdateServizioByID(int id, Servizio servizio);
    }
}
