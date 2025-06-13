using Supermercato_DB;
using Supermercato_DB.Interfaces;
using Supermercato_DB.Repos;

IUserRepository userRepository = new UserRepository();


User user = new User();
Supermercato supermercato = new Supermercato();
// INSERIMENTO CREDENZIALI CON CONTROLLO SE SONO NULL O NON SONO PRESENTI NEL DB
do
{
    do
    {
        Console.WriteLine("\nInserimento credenziali Utente\n");

    } while (user.InserisciCredenziali() == false);

    Console.WriteLine("\nRicerca dell' utente nel DB\n");

} while (userRepository.GetUser(user) == false);



Console.WriteLine("\n\n  BENVENUTO NEL SUPERMERCATO  ");

IProductRepository productRepository = new ProductRepository();


bool permanenza = true;

//MENU PRINCIPALE
do
{
    
} while (supermercato.Menu(permanenza, productRepository, userRepository)==true);





