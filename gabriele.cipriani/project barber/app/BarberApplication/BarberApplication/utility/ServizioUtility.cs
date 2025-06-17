using BarberApplication.@class;
using BarberApplication.Interfaces;
using BarberApplication.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApplication.utility
{
    public class ServizioUtility : IServizioUtility
    {
        public void CreateServizio(Servizio servizio)
        {

            IDatabaseServizio databaseServizio = new ServizioRepository();
            if (databaseServizio.CreateNewServizio(servizio))
            {
                Console.WriteLine("Servizio creato con successo!");
                return;
            }
            
            
                Console.WriteLine("Errore nella creazione del servizio.");
            
        }

        public bool DeleteServizio(int idServizio)
        {
            IDatabaseServizio databaseClient = new ServizioRepository();

            if (databaseClient.DeleteServizioByID(idServizio))
            {
                Console.WriteLine("Servizio eliminato con successo!");
                return true;
            }
            
            
                Console.WriteLine("Errore nell'eliminazione del servizio.");
                return false;
            
        }

        public void GetAllServizio()
        {
            IDatabaseServizio databaseServizio = new ServizioRepository();

            Console.WriteLine("La lista dei servizi è: \n");
            if (databaseServizio.GetAllServizi())
            {
                Console.WriteLine("Servizi recuperati con successo!");
                return;
            }
            
            
                Console.WriteLine("Errore nel recupero dei servizi.");
            
        }

        public bool GetServizioByID(int idServizio)
        {
            IDatabaseServizio databaseServizio = new ServizioRepository();
            if (databaseServizio.GetServizioByID(idServizio))
            {
                Console.WriteLine("Servizio recuperato con successo!");
                return true;
            }
           
           
                Console.WriteLine("Errore nel recupero del servizio.");
                return false;
            
        }
    }
}
