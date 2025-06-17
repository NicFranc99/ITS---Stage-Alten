using BarberApplication.@class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApplication.Interfaces
{
    public interface IServizioUtility
    {
        public void CreateServizio(Servizio servizio);
        public bool DeleteServizio(int id);
        public void GetAllServizio();
        public bool GetServizioByID(int id);
    }
}
