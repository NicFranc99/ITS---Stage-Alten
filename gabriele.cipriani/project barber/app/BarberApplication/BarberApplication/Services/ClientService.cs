using BarberApplication.@class;
using BarberApplication.Interfaces;
using BarberApplication.Repos;


namespace BarberApplication.utility
{
    public class ClientService(IClientRepository databaseClient) : IClientService
    {
        void IClientService.CreateClient(Client cliente)
        {
            
            

            if (databaseClient.CreateNewClient(cliente))
            {
                Console.WriteLine("Cliente creato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nella creazione del cliente.");
            }
        }

        bool IClientService.DeleteClient(int id)
        {
            

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

        void IClientService.GetAllClients()
        {
           

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

        bool IClientService.GetClientsByID(int id)
        {
            

            if (databaseClient.GetClientByID(id))
            {
                Console.WriteLine("Cliente recuperato con successo!");
                return true;
            }
            Console.WriteLine("Errore nel recupero del cliente.");
            return false;
        }

        bool IClientService.UpdateClientsByID(int id, Client cliente)
        {
            

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
