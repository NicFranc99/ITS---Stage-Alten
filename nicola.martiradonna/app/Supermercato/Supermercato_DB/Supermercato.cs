using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Supermercato_DB.Interfaces;

namespace Supermercato_DB
{
    public class Supermercato
    {
        public int sceltaUtente { get; set; }



        public bool Menu(bool permanenza, IProductRepository productRepository, IUserRepository userRepository)
        {
            do
            {
                try
                {
                    Console.WriteLine("\nSeleziona l' operazione che vuoi eseguire");
                    Console.WriteLine("\n1) Seleziona tutti i prodotti presenti nel magazzino\n2) Crea uno scontrino\n3) Inserisci un nuovo prodotto nel Magazzino\n4) Chiusura Programma");
                    sceltaUtente = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n!!  Formato sbagliato  !!");
                }

            } while (!(sceltaUtente is int) && sceltaUtente < 0 || sceltaUtente > 4);


            switch (sceltaUtente)
            {
                case 1:
                    productRepository.GetAllProducts();
                    break;

                case 2:
                    Scontrino scontrino = new Scontrino();
                    do
                    {

                    } while (scontrino.Menu(productRepository));
                    break;

                case 3:

                    Console.WriteLine("\n  INSERIMENTO NUOVO PRODOTTO  ");
                    Product product = new Product();

                    do
                    {

                    } while (!product.InserisciNuovoProdotto());

                    productRepository.CreateNewProduct(product);

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
