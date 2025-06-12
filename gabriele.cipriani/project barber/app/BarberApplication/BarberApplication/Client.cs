using BarberApplication.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BarberApplication.Repos.CustomerRepository;



namespace BarberApplication
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }

        public static void CreateClient()
        {
            var client = new Client();

            Console.WriteLine("Inserisci il nome:");
            client.FirstName = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome:");
            client.LastName = Console.ReadLine();

            Console.WriteLine("Inserisci l'età:");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Età non valida.");
                return;
            }
            client.Age = age;

            Console.WriteLine("Inserisci l'email:");
            client.Email = Console.ReadLine();

            Console.WriteLine("Inserisci il numero di telefono:");
            if (!long.TryParse(Console.ReadLine(), out long phoneNumber))
            {
                Console.WriteLine("Numero di telefono non valido.");
                return;
            }
            client.PhoneNumber = phoneNumber;

            IDatabaseClient databaseClient = new CustomerRepository();

            if (databaseClient.CreateNewClient(client))
            {
                Console.WriteLine("Cliente creato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nella creazione del cliente.");
            }
        }

        public static void DeleteClient()
        {
            Console.WriteLine("Inserisci l'id del cliente da eliminare:");
            if (!int.TryParse(Console.ReadLine(), out int clientId))
            {
                Console.WriteLine("ID non valido.");
                return;
            }

            IDatabaseClient databaseClient = new CustomerRepository();

            if (databaseClient.DeleteClientByID(clientId))
            {
                Console.WriteLine("Cliente eliminato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nell'eliminazione del cliente.");
            }
        }

        public static void GetAllClients()
        {
            IDatabaseClient databaseClient = new CustomerRepository();
            
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

        public static void GetClientsByID()
        {
            Console.WriteLine("Inserisci l'id del cliente da cercare:");
            if (!int.TryParse(Console.ReadLine(), out int clientId))
            {
                Console.WriteLine("ID non valido.");
                return;
            }

            IDatabaseClient databaseClient = new CustomerRepository();

            if (databaseClient.GetClientByID(clientId))
            {
                Console.WriteLine("Cliente recuperato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nel recupero del cliente.");
            }
        }
    }
}
