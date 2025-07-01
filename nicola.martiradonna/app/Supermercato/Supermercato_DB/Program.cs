using Supermercato_DB;
using Supermercato_DB.Interfaces;
using Supermercato_DB.Repos;
using Supermercato_DB.Services;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


HostApplicationBuilder builder = Host.CreateApplicationBuilder();


var userService1 = builder.Services.AddScoped<IUserService, UserService>();
var userRepo= builder.Services.AddScoped<IUserRepository, UserRepository>();
var productService1 = builder.Services.AddScoped<IProductService, ProductService>();
var productRepo = builder.Services.AddScoped<IProductRepository, ProductRepository>();
var categoryRepo = builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();



var serviceProvider = builder.Services.BuildServiceProvider();


IUserService userService = serviceProvider.GetRequiredService<IUserService>();
IUserRepository userRepository = serviceProvider.GetRequiredService<IUserRepository>();

IProductRepository productRepository = serviceProvider.GetRequiredService<IProductRepository>();
ICategoryRepository categoryRepository = serviceProvider.GetRequiredService<ICategoryRepository>();

IProductService productService = serviceProvider.GetRequiredService<IProductService>();




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






