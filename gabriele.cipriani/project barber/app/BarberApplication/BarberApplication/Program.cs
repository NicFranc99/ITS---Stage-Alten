using BarberApplication.@class;
using BarberApplication.Interfaces;
using BarberApplication.Repos;
using BarberApplication.utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

var userService=builder.Services.AddScoped<IUserRepository, UserRepository>();

var clientDatabaseService = builder.Services.AddScoped<IClientRepository, ClientRepository>();

var clientService = builder.Services.AddScoped<IClientService, ClientService>();

var servizioService = builder.Services.AddScoped<IServizioService, ServizioService>();

var databaseServizio = builder.Services.AddScoped<IServizioRepository, ServizioRepository>();
var serviceProvider = builder.Services.BuildServiceProvider();

User user = new User();
Client cliente = new Client();
Servizio servizio = new Servizio();
int idGet = 0;
int idServizio = 0;
int scelta = 0;

IClienteServizioRepository repository = new ClienteServizioRepository();
    



var databaseUser= serviceProvider.GetRequiredService<IUserRepository>();

IClientService clientUtility = serviceProvider.GetRequiredService<IClientService>();
IServizioService servizioUtility = serviceProvider.GetRequiredService<IServizioService>();
IClienteServizioService utility = serviceProvider.GetRequiredService<IClienteServizioService>();


do
{
    do
    {
        Console.WriteLine("\nInserimento credenziali Utente\n");

    } while (!user.InserisciCredenziali());

    Console.WriteLine("Ricerca dell' utente nel DB");

} while (!databaseUser.GetUser(user));

Console.Clear();


int sceltaPrincipale;

do
{
    Console.WriteLine("\n=== MENU PRINCIPALE ===");
    Console.WriteLine("1. Operazioni sui Clienti");
    Console.WriteLine("2. Operazioni sui Servizi");
    Console.WriteLine("3. Operazioni Generali sui Servizi");
    Console.WriteLine("0. Esci");

    while (!int.TryParse(Console.ReadLine(), out sceltaPrincipale) || sceltaPrincipale < 0 || sceltaPrincipale > 3)
    {
        Console.WriteLine("Scelta non valida. Inserisci un numero tra 0 e 3.");
    }

    switch (sceltaPrincipale)
    {
        case 1:
            MostraMenuClienti();
            break;
        case 2:
            MostraMenuServizi();
            break;
        case 3:
            utility.AvviaOperazioni();
            break;
        case 0:
            Console.WriteLine("Uscita dall'applicazione...");
            break;
    }

} while (sceltaPrincipale != 0);
void MostraMenuClienti()
{
    int scelta;
    do
    {
        Console.WriteLine("\n--- OPERAZIONI CLIENTI ---");
        Console.WriteLine("1. Inserisci Cliente");
        Console.WriteLine("2. Elimina Cliente");
        Console.WriteLine("3. Recupera Cliente per ID");
        Console.WriteLine("4. Aggiorna Cliente per ID");
        Console.WriteLine("5. Visualizza tutti i Clienti");
        Console.WriteLine("0. Torna al menu principale");

        while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 5)
        {
            Console.WriteLine("Scelta non valida. Inserisci un numero compreso tra 0 e 5.");
        }

        switch (scelta)
        {
            case 1:
                var cliente = ValorizzaClient();
                clientUtility.CreateClient(cliente);
                break;
            case 2:
                clientUtility.GetAllClients();
                int id;
                do { id = InsertIdForDeleteClient(); }
                while (!clientUtility.DeleteClient(id));
                break;
            case 3:
                clientUtility.GetAllClients();
                int idGet;
                do { idGet = InsertIdForGetClient(); }
                while (!clientUtility.GetClientsByID(idGet));
                break;
            case 4:
                clientUtility.GetAllClients();
                do
                {
                    idGet = InsertIdForGetClient();
                    do { cliente = InsertNewDataForUpdatingClient(); }
                    while (cliente == null);
                }
                while (!clientUtility.UpdateClientsByID(idGet, cliente));
                break;
            case 5:
                clientUtility.GetAllClients();
                break;
        }

    } while (scelta != 0);
}
void MostraMenuServizi()
{
    int scelta;
    do
    {
        Console.WriteLine("\n--- OPERAZIONI SERVIZI ---");
        Console.WriteLine("1. Inserisci Servizio");
        Console.WriteLine("2. Elimina Servizio");
        Console.WriteLine("3. Recupera Servizio per ID");
        Console.WriteLine("4. Visualizza tutti i Servizi");
        Console.WriteLine("5. Modifica servizio");
        Console.WriteLine("0. Torna al menu principale");

        while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 5)
        {
            Console.WriteLine("Scelta non valida. Inserisci un numero compreso tra 0 e 5.");
        }

        switch (scelta)
        {
            case 1:
                var servizio = CreaServizio();
                servizioUtility.CreateServizio(servizio);
                break;
            case 2:
                servizioUtility.GetAllServizio();
                int id;
                do { id = InsertIdForDeleteServizio(); }
                while (!servizioUtility.DeleteServizio(id));
                break;
            case 3:
                servizioUtility.GetAllServizio();
                do { id = InsertIdForGetServizio(); }
                while (!servizioUtility.GetServizioByID(id));
                break;
            case 4:
                servizioUtility.GetAllServizio();
                break;
            case 5:
                servizioUtility.GetAllServizio();
                do
                {
                    idGet = InsertIdForGetServizio();
                    do { servizio = InsertNewDataForUpdatingServizio(); }
                    while (servizio == null);
                }
                while (!servizioUtility.UpdateServizioByID(idGet, servizio));
                break;
        }

    } while (scelta != 0);
}

























Servizio CreaServizio()
{
    var servizio = new Servizio();

    
    string nome;
    do
    {
        Console.WriteLine("Inserisci il nome del servizio:");
        nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Il nome non può essere vuoto.");
        }

    } while (string.IsNullOrWhiteSpace(nome));
    servizio.ServiceName = nome;

    
    decimal price;
    bool prezzoValido;
    do
    {
        Console.WriteLine("Inserisci il prezzo del servizio con formato [00,00]:");
        prezzoValido = decimal.TryParse(Console.ReadLine(), out price);

        if (!prezzoValido || price < 0)
        {
            Console.WriteLine("Prezzo non valido. Inserisci un valore positivo.");
            prezzoValido = false;
        }

    } while (!prezzoValido);
    servizio.ServicePrice = price;

    return servizio;
}
int InsertIdForDeleteServizio()
{
    Console.WriteLine("Inserisci l'id del servizio da eliminare:");
    if (!int.TryParse(Console.ReadLine(), out int servizioId) || servizioId <= 0)
    {
        Console.WriteLine("ID non valido. Riprova.");
    }
    return servizioId;
}
int InsertIdForGetServizio()
{
    Console.WriteLine("Inserisci l'id del servizio da recuperare:");
    if (!int.TryParse(Console.ReadLine(), out int idGet) || idGet <= 0)
    {
        Console.WriteLine("ID non valido. Deve essere un numero intero positivo.");
    }
    return idGet;
}


Servizio InsertNewDataForUpdatingServizio()
{
    var servizio = new Servizio();

    Console.WriteLine("Inserisci il nuovo nome del servizio (lascia vuoto per impostare NULL):");
    string inputNome = Console.ReadLine();
    servizio.ServiceName = string.IsNullOrWhiteSpace(inputNome) ? null : inputNome;

    Console.WriteLine("Inserisci il nuovo prezzo del servizio (lascia vuoto per impostare NULL):");
    string inputPrice = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(inputPrice))
    {
        servizio.ServicePrice = null;
    }
    else
    {
        decimal parsedPrice;
        while (!decimal.TryParse(inputPrice, out parsedPrice) || parsedPrice < 0)
        {
            Console.WriteLine("Il prezzo inserito non è valido. Riprova (lascia vuoto per impostare NULL):");
            inputPrice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputPrice))
            {
                parsedPrice = 0;
                break;
            }
        }
        
        servizio.ServicePrice = string.IsNullOrWhiteSpace(inputPrice) ? null : parsedPrice;
    }

    return servizio;
}
    


Client ValorizzaClient()
{
    Client client = new Client();
    int age;

    
    string InputValido(string messaggio)
    {
        string input;
        while (true)
        {
            Console.WriteLine(messaggio);
            input = Console.ReadLine();
            //out_ serve ad ignorare la conversione del valore in un out parameter, in questo caso non ci interessa il valore convertito ma solo se la conversione ha successo o meno.
            if (string.IsNullOrWhiteSpace(input) || int.TryParse(input, out _))
            {
                Console.WriteLine("Input non valido. Inserisci un testo non vuoto e non numerico.");
            }
            else
            {
                return input;
            }
        }
    }

    client.FirstName = InputValido("Inserisci il nome:");
    client.LastName = InputValido("Inserisci il cognome:");

    while (true)
    {
        Console.WriteLine("Inserisci l'età:");
        string inputAge = Console.ReadLine();

        if (!int.TryParse(inputAge, out age) || age < 0 || age > 120)
        {
            Console.WriteLine("Età non valida. Inserisci un numero intero compreso tra 0 e 120.");
        }
        else
        {
            break;
        }
    }
    client.Age = age;

    client.Email = InputValido("Inserisci l'email:");

    while (true)
    {
        Console.WriteLine("Inserisci il numero di telefono:");
        string inputPhone = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputPhone) || !long.TryParse(inputPhone, out long phoneNumber))
        {
            Console.WriteLine("Numero di telefono non valido. Inserisci solo cifre.");
        }
        else
        {
            client.PhoneNumber = phoneNumber;
            break;
        }
    }

    return client;
}

int InsertIdForDeleteClient()
{
    Console.WriteLine("Inserisci l'id del cliente da eliminare:");
    if (!int.TryParse(Console.ReadLine(), out int clientId) || clientId <= 0)
    {
        Console.WriteLine("ID non valido. Riprova.");

    }
    return clientId;
}

int InsertIdForGetClient()
{


    Console.WriteLine("Inserisci l'id del cliente da recuperare:");
    string input = Console.ReadLine();


    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out idGet) || idGet <= 0)
    {
        Console.WriteLine("ID non valido. Deve essere un numero intero positivo.");

    }

    return idGet;

}
Client InsertNewDataForUpdatingClient()
{
    var client = new Client();

 
    do
    {
        Console.WriteLine("Inserisci il nuovo nome:");
        client.FirstName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(client.FirstName))
            Console.WriteLine("Il nome non può essere vuoto.");
    } while (string.IsNullOrWhiteSpace(client.FirstName));

    
    do
    {
        Console.WriteLine("Inserisci il nuovo cognome:");
        client.LastName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(client.LastName))
            Console.WriteLine("Il cognome non può essere vuoto.");
    } while (string.IsNullOrWhiteSpace(client.LastName));

    
    int age;
    do
    {
        Console.WriteLine("Inserisci la nuova età (5-99):");
    } while (!int.TryParse(Console.ReadLine(), out age) || age < 5 || age > 99);
    client.Age = age;

    
    do
    {
        Console.WriteLine("Inserisci la nuova email:");
        client.Email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(client.Email) )
            Console.WriteLine("Email non valida.");
    } while (string.IsNullOrWhiteSpace(client.Email) );

   
    long phoneNumber;
    do
    {
        Console.WriteLine("Inserisci il nuovo numero di telefono (minimo 7 cifre):");
        string input = Console.ReadLine();
        bool isValid = long.TryParse(input, out phoneNumber);
        if (!isValid) 
            Console.WriteLine("Numero di telefono non valido.");
    } while (phoneNumber.ToString().Length < 10);

    client.PhoneNumber = phoneNumber;

    return client;
}







