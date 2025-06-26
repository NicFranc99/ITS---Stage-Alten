using Supermercato_DB;
using Supermercato_DB.Interfaces;
using Supermercato_DB.Repos;
using Supermercato_DB.Services;
using Xunit;



IUserRepository userRepository = new UserRepository();
IProductRepository productRepository = new ProductRepository();
ICategoryRepository categoryRepository = new CategoryRepository();
IProductService productService = new ProductService();
IUserService userService = new UserService();



User user = new User();
Supermercato supermercato = new Supermercato(productRepository,productService,categoryRepository);
// INSERIMENTO CREDENZIALI CON CONTROLLO SE SONO NULL O NON SONO PRESENTI NEL DB
do
{
    do
    {

        Console.WriteLine("\nInserimento credenziali Utente\n");

    } while (!userService.InserisciCredenziali(user));

    Console.WriteLine("\nRicerca dell' utente nel DB\n");

} while (!userRepository.GetUser(user));


if (user.Id_ruolo == 3)
{
    Console.WriteLine("\n!!  Benvenuto Cassiere  !!");

    bool permanenza;

    do
    {
        Console.WriteLine("\nNuovo Scontrino ");
        Scontrino scontrino = new Scontrino();
        permanenza=scontrino.Menu(productRepository, productService);

    } while (permanenza);
}

if(user.Id_ruolo == 4)
{
     
    Console.WriteLine("\n!!  Benvenuto Magazziniere  !!");

    bool permanenza = true;
    do 
    {

    }while(supermercato.Menu(permanenza));
}






