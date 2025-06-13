using BarberApplication.Interfaces;
using BarberApplication.Repos;

namespace BarberApplication
{
    public class Servizio
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }

        public static void CreateServizio()
        {
            var servizio = new Servizio();
            Console.WriteLine("Inserisci il nome del servizio:");
            servizio.ServiceName = Console.ReadLine();
            Console.WriteLine("Inserisci il prezzo del servizio:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Prezzo non valido.");
                return;
            }
            servizio.ServicePrice = price;
            IDatabaseServizio databaseServizio = new ServizioRepository();
            if (databaseServizio.CreateNewServizio(servizio))
            {
                Console.WriteLine("Servizio creato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nella creazione del servizio.");
            }
        }

        public static void DeleteServizio()
        {
            Console.WriteLine("Inserisci l'id del servizio da eliminare:");
            if (!int.TryParse(Console.ReadLine(), out int servizioId))
            {
                Console.WriteLine("ID non valido.");
                return;
            }

            IDatabaseServizio databaseClient = new ServizioRepository();

            if (databaseClient.DeleteServizioByID(servizioId))
            {
                Console.WriteLine("Servizio eliminato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nell'eliminazione del servizio.");
            }
        }

        public static void GetAllServizi()
        {
            IDatabaseServizio databaseServizio = new ServizioRepository();

            Console.WriteLine("La lista dei servizi è: \n");
            if (databaseServizio.GetAllServizi())
            {
                Console.WriteLine("Clienti recuperati con successo!");
            }
            else
            {
                Console.WriteLine("Errore nel recupero dei clienti.");
            }
        }
        public static void GetServiziById()
        {
            Console.WriteLine("Inserisci l'id del servizio da recuperare:");
            if (!int.TryParse(Console.ReadLine(), out int servizioId))
            {
                Console.WriteLine("ID non valido.");
                return;
            }
            IDatabaseServizio databaseServizio = new ServizioRepository();
            if (databaseServizio.GetServizioByID(servizioId))
            {
                Console.WriteLine("Servizio recuperato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nel recupero del servizio.");
            }
        }
        public static void UpdateServiziById()
        {
            Console.WriteLine("Inserisci l'id del servizio da aggiornare:");
            if (!int.TryParse(Console.ReadLine(), out int servizioId))
            {
                Console.WriteLine("ID non valido.");
                return;
            }
            var servizio = new Servizio();
            Console.WriteLine("Inserisci il nuovo nome del servizio:");
            servizio.ServiceName = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo prezzo del servizio:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Prezzo non valido.");
                return;
            }
            servizio.ServicePrice = price;
            IDatabaseServizio databaseServizio = new ServizioRepository();
            if (databaseServizio.UpdateServizioByID(servizioId, servizio))
            {
                Console.WriteLine("Servizio aggiornato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nell'aggiornamento del servizio.");
            }
        }
    }
}
