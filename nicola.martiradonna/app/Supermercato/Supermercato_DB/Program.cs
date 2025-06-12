using Supermercato_DB;
using Supermercato_DB.Interfaces;
using Supermercato_DB.Repos;

IUserRepository databaseUser = new UserRepository();

User user = new User();

do
{
    do
    {
        Console.WriteLine("\nInserimento credenziali Utente\n");

    } while (user.InserisciCredenziali() == false);


    Console.WriteLine("Ricerca dell' utente nel DB");

} while (databaseUser.GetUser(user) == false);