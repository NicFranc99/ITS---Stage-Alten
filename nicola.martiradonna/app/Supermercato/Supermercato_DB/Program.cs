using Supermercato_DB;
using Supermercato_DB.Interfaces;
using Supermercato_DB.Repos;
using Supermercato_DB.Services;

IUserRepository userRepository = new UserRepository();
IProductRepository productRepository = new ProductRepository();
ICategoryRepository categoryRepository = new CategoryRepository();
IProductService productService = new ProductService();



User user = new User();
Supermercato supermercato = new Supermercato(productRepository,productService,categoryRepository);
// INSERIMENTO CREDENZIALI CON CONTROLLO SE SONO NULL O NON SONO PRESENTI NEL DB
do
{
    do
    {
        Console.WriteLine("\nInserimento credenziali Utente\n");

    } while (!user.InserisciCredenziali());

    Console.WriteLine("\nRicerca dell' utente nel DB\n");

} while (!userRepository.GetUser(user));


Console.WriteLine("\n\n  BENVENUTO NEL SUPERMERCATO  ");

bool permanenza = true;

//MENU PRINCIPALE
do
{
    
} while (supermercato.Menu(permanenza));





