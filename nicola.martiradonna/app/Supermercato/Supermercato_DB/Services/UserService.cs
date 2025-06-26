using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercato_DB.Interfaces;

namespace Supermercato_DB.Services
{
    public class UserService :IUserService
    {
        public bool InserisciCredenziali(User user)
        {

            Console.WriteLine("Inserisci il tuo Username");
            user.Username = Console.ReadLine();

            Console.WriteLine("Inserisci la tua Password");
            user.Password = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                Console.WriteLine("!!  Errore credenziali  !!");
                return false;
            }

            Console.WriteLine("Credenziali OK");
            return true;

        }
    }
}
