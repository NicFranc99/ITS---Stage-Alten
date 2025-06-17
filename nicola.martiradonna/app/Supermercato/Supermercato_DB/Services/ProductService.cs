using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercato_DB.Interfaces;

namespace Supermercato_DB.Services
{
    public class ProductService : IProductService
    {
        public bool AddProduct(Product product)
        {
            Console.WriteLine("\nInserisci il nome del prodotto");
            product.Nome = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(product.Nome) || !(product.Nome is string))
            {
                Console.WriteLine("\nInserisci un nome valido!");
                product.Nome = Console.ReadLine();
            }


            try
            {

                Console.WriteLine("\nInserisci il prezzo del prodotto [Formato 00,00] :");
                product.Prezzo = Convert.ToDecimal(Console.ReadLine());


                while (product.Prezzo <= 0 || product.Prezzo == null || product.Prezzo is string)
                {
                    Console.WriteLine("\nInserisci un prezzo valido!");
                    product.Prezzo = Convert.ToDecimal(Console.ReadLine());
                }

            }
            catch (FormatException)
            {

                while (product.Prezzo <= 0 || product.Prezzo == null || product.Prezzo is string)
                {
                    try
                    {
                        Console.WriteLine("\nInserisci un prezzo valido!");
                        product.Prezzo = Convert.ToDecimal(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }

                }
            }

            try
            {

                Console.WriteLine("\nInserisci la quantità del prodotto :");
                product.Quantita = Convert.ToInt32(Console.ReadLine());

                while (product.Quantita <= 0 || product.Quantita == null || product.Quantita is string || product.Quantita is decimal)
                {
                    Console.WriteLine("\nInserisci una quantità valida");
                    product.Quantita = Convert.ToInt32(Console.ReadLine());
                }

            }
            catch (FormatException)
            {
                while (product.Quantita <= 0 || product.Quantita == null || product.Quantita is string || product.Quantita is decimal)
                {
                    try
                    {
                        Console.WriteLine("\nInserisci una quantità valida");
                        product.Quantita = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }
                }
            }

            return true;

        }

        public int AddProductDescription(Product product, ICategoryRepository categoryRepository)
        {
            int IdCategoria = 0;
            //STAMPA TUTTE LE CATEGORIE DI PRODOTTI DISPONIBILI
            categoryRepository.GetProductsDescription();
            do
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\nInserisci l' ID della categoria da assegnare al prodotto: ");
                        IdCategoria = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }
                } while (IdCategoria <= 0 || IdCategoria is string);
                //SE NON TROVA ALCUNA CATEGORIA CON QUELL' ID FA RICHIEDRE L'ID UN' ALTRA VOLTA
            } while (!categoryRepository.GetProductDescriptionById(IdCategoria));

            return IdCategoria;
        }
    }
}
