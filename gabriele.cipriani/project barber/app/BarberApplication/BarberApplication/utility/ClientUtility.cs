using BarberApplication.@class;
using BarberApplication.Interfaces;
using BarberApplication.Repos;


namespace BarberApplication.utility
{
    public class ClientUtility : IClientUtility
    {
        void IClientUtility.CreateClient(Client cliente)
        {
            
            IDatabaseClient databaseClient = new ClientRepository();

            if (databaseClient.CreateNewClient(cliente))
            {
                Console.WriteLine("Cliente creato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nella creazione del cliente.");
            }
        }

        bool IClientUtility.DeleteClient(int id)
        {
            IDatabaseClient databaseClient = new ClientRepository();

            var client = databaseClient.GetClientByID(id);
            if (client == null)
            {
                Console.WriteLine($"Il cliente con id {id} non esiste. Riprova.");
                return false;
            }

            if (databaseClient.DeleteClientByID(id))
            {
                Console.WriteLine("Cliente eliminato con successo!");
                return true;
            }
            else
            {
                Console.WriteLine("Errore nell'eliminazione del cliente. Riprova.");
                return false;
            }
        }

        void IClientUtility.GetAllClients()
        {
            IDatabaseClient databaseClient = new ClientRepository();

            Console.WriteLine("La lista dei clienti è: \n");
            if (databaseClient.GetAllClient())
            {
                Console.WriteLine("Clienti recuperati con successo!");
            }
            else
            {
                Console.WriteLine("Errore nel recupero dei clienti.");
            }
        }

        bool IClientUtility.GetClientsByID(int id)
        {
            IDatabaseClient databaseClient = new ClientRepository();

            if (databaseClient.GetClientByID(id))
            {
                Console.WriteLine("Cliente recuperato con successo!");
                return true;
            }
            Console.WriteLine("Errore nel recupero del cliente.");
            return false;
        }

        bool IClientUtility.UpdateClientsByID(int id, Client cliente)
        {
            IDatabaseClient databaseClient = new ClientRepository();

            if (databaseClient.UpdateClientByID(id, cliente))
            {
                Console.WriteLine("Cliente aggiornato con successo!");
                return true;
            }
            else
            {
                Console.WriteLine("Errore nell'aggiornamento del cliente.");
                return false;
            }
        }
    }
}
