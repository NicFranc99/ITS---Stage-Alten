using BarberApplication;
using BarberApplication.Interfaces;
using BarberApplication.Repos;
using static BarberApplication.Repos.CustomerRepository;

IUserRepository databaseUser = new UserRepository();
IDatabaseClient databaseClient = new CustomerRepository();
User user = new User();
Client client = new Client();
//do  
//{  
//    do  
//    {  
//        Console.WriteLine("\nInserimento credenziali Utente\n");  

//    } while (user.InserisciCredenziali() == false);  

//    Console.WriteLine("Ricerca dell' utente nel DB");  

//} while (databaseUser.GetUser(user) == false);  

//Client.CreateClient();
//Client.DeleteClient();
//Client.GetAllClients();
Client.GetClientsByID();
