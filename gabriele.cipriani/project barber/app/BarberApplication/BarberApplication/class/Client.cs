using BarberApplication.Interfaces;
using BarberApplication.Repos;

namespace BarberApplication.@class
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }

        //public  void CreateClient()
        //{
        //    var client = new Client();
        //    int age;

        //    Console.WriteLine("Inserisci il nome:");
        //    client.FirstName = Console.ReadLine();

        //    Console.WriteLine("Inserisci il cognome:");
        //    client.LastName = Console.ReadLine();

            
        //    while (true)
        //    {
        //        Console.WriteLine("Inserisci l'età:");
        //        string inputAge = Console.ReadLine();

        //        if (!int.TryParse(inputAge, out age) || age < 0 || age > 120)
        //        {
        //            Console.WriteLine("Età non valida. Inserisci un numero intero compreso tra 0 e 120.");
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    client.Age = age;


        //    Console.WriteLine("Inserisci l'email:");
        //    client.Email = Console.ReadLine();

        //    Console.WriteLine("Inserisci il numero di telefono:");
        //    if (!long.TryParse(Console.ReadLine(), out long phoneNumber))
        //    {
        //        Console.WriteLine("Numero di telefono non valido.");
        //        return;
        //    }
        //    client.PhoneNumber = phoneNumber;

        //    IDatabaseClient databaseClient = new CustomerRepository();

        //    if (databaseClient.CreateNewClient(client))
        //    {
        //        Console.WriteLine("Cliente creato con successo!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Errore nella creazione del cliente.");
        //    }
        //}

        //public  void DeleteClient()
        //{
        //    IDatabaseClient databaseClient = new CustomerRepository();
        //    while (true)
        //    {
        //        Console.WriteLine("Inserisci l'id del cliente da eliminare:");
        //        if (!int.TryParse(Console.ReadLine(), out int clientId) || clientId <= 0)
        //        {
        //            Console.WriteLine("ID non valido. Riprova.");
        //            continue; 
        //        }

        //        var client = databaseClient.GetClientByID(clientId);
        //        if (client == null)
        //        {
        //            Console.WriteLine($"Il cliente con id {clientId} non esiste. Riprova.");
        //            continue; 
        //        }

        //        if (databaseClient.DeleteClientByID(clientId))
        //        {
        //            Console.WriteLine("Cliente eliminato con successo!");
        //            break; 
        //        }
        //        else
        //        {
        //            Console.WriteLine("Errore nell'eliminazione del cliente. Riprova.");
                    
        //        }
        //    }
        //}

        //public  void GetAllClients()
        //{
        //    IDatabaseClient databaseClient = new CustomerRepository();

        //    Console.WriteLine("La lista dei clienti è: \n");
        //    if (databaseClient.GetAllClient())
        //    {
        //        Console.WriteLine("Clienti recuperati con successo!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Errore nel recupero dei clienti.");
        //    }
        //}

        //public  void GetClientsByID()
        //{
        //    IDatabaseClient databaseClient = new CustomerRepository();
        //    int clientId;

        //    while (true)
        //    {
        //        Console.WriteLine("Inserisci l'id del cliente da recuperare:");
        //        string input = Console.ReadLine();


        //        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out clientId) || clientId <= 0)
        //        {
        //            Console.WriteLine("ID non valido. Deve essere un numero intero positivo.");
        //            continue;
        //        }

        //        break;
        //    }

        //    if (databaseClient.GetClientByID(clientId))
        //    {
        //        Console.WriteLine("Cliente recuperato con successo!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Errore nel recupero del cliente.");
        //    }
        //}

        //public  void UpdateClientsByID()
        //{
        //    IDatabaseClient databaseClient = new CustomerRepository();
        //    int clientId;

        //    while (true)
        //    {
        //        Console.WriteLine("Inserisci l'id del cliente da modificare:");
        //        string input = Console.ReadLine();


        //        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out clientId) || clientId <= 0)
        //        {
        //            Console.WriteLine("ID non valido. Deve essere un numero intero positivo.");
        //            continue;
        //        }


        //        if (!databaseClient.GetClientByID(clientId))
        //        {
        //            Console.WriteLine("ID non trovato nel database. Riprova.");
                    
        //        }


        //        break;
        //    }

        //    var client = new Client();

        //    Console.WriteLine("Inserisci il nuovo nome:");
        //    client.FirstName = Console.ReadLine();

        //    Console.WriteLine("Inserisci il nuovo cognome:");
        //    client.LastName = Console.ReadLine();

        //    Console.WriteLine("Inserisci la nuova età:");
        //    if (!int.TryParse(Console.ReadLine(), out int age))
        //    {
        //        Console.WriteLine("Età non valida.");
        //        return;
        //    }
        //    client.Age = age;

        //    Console.WriteLine("Inserisci la nuova email:");
        //    client.Email = Console.ReadLine();

        //    Console.WriteLine("Inserisci il nuovo numero di telefono:");
        //    if (!long.TryParse(Console.ReadLine(), out long phoneNumber))
        //    {
        //        Console.WriteLine("Numero di telefono non valido.");
        //        return;
        //    }
        //    client.PhoneNumber = phoneNumber;

        //    if (databaseClient.UpdateClientByID(clientId, client))
        //    {
        //        Console.WriteLine("Cliente aggiornato con successo!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Errore nell'aggiornamento del cliente.");
        //    }
        //}
    }
}
