using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato_DB
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


        public bool InserisciCredenziali()
        {
            
                Console.WriteLine("Inserisci il tuo Username");
                Username = Console.ReadLine();

                Console.WriteLine("Inserisci la tua Password");
                Password = Console.ReadLine();

                
            if(Username=="" || Password == "")
            {
                Console.WriteLine("!!  Errore credenziali  !!");
                return false;
            }
            else
            {
                Console.WriteLine("Credenziali OK");
                return true;
            }
        }

    }
        
}
