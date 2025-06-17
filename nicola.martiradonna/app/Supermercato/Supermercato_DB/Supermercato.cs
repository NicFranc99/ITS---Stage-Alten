using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Supermercato_DB.Interfaces;
using Supermercato_DB.Services;

namespace Supermercato_DB
{
    public class Supermercato
    {
        public int SceltaUtente { get; set; }

        private readonly IProductRepository productRepository;

        private readonly IProductService productService;

        private readonly ICategoryRepository categoryRepository;


        public Supermercato(IProductRepository ProductRepository, IProductService ProductService, ICategoryRepository CategoryRepository)
        {
            productRepository = ProductRepository;
            productService = ProductService;
            categoryRepository = CategoryRepository;
        }
        public bool Menu(bool permanenza)
        {
            do
            {
                try
                {
                    Console.WriteLine("\nSeleziona l' operazione che vuoi eseguire");
                    Console.WriteLine("\n1) Seleziona tutti i prodotti presenti nel magazzino\n2) Crea uno scontrino\n3) Inserisci un nuovo prodotto nel Magazzino\n4) Chiusura Programma");
                    SceltaUtente = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n!!  Formato sbagliato  !!");
                }

            } while (!(SceltaUtente is int) && SceltaUtente < 0 || SceltaUtente > 4);


            switch (SceltaUtente)
            {
                case 1:
                    productRepository.GetAllProducts();
                    break;

                case 2:
                    Scontrino scontrino = new Scontrino();
                    Console.WriteLine("\nNUOVO SCONTRINO");

                    do
                    {

                    } while (scontrino.Menu(productRepository));
                    break;

                case 3:

                    Console.WriteLine("\n  INSERIMENTO NUOVO PRODOTTO  ");
                    Product product = new Product();

                    do
                    {
                      
                    } while (!productService.AddProduct(product));

                    //ASSEGNA LA DESCRIZIONE TRAMITE ID AL PRODOTTO
                    int IdDescription= productService.AddProductDescription(product,categoryRepository);

                    //INSERISCE IL NUOVO PRODOTTO NEL DB CON L'ID DELLA CATEGORIA ASSEGNATO IN PRECEDENZA
                    productRepository.CreateNewProduct(product,IdDescription);

                    break;
                case 4:

                    Console.WriteLine("Chiusura programma...");
                    permanenza = false;
                    break;
            }
            return permanenza;
        }

    }
}
