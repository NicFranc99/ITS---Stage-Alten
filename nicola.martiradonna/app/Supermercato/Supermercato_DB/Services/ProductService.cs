using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Supermercato_DB.Interfaces;

namespace Supermercato_DB.Services
{
    public class ProductService : IProductService
    {
        public int SceltaMenu { get; set; }

        public string mxs { get; set; } = "Inserisci l' id del prodotto da modificare";

        public bool AddProduct(Product product)
        {

            product.Nome = InserisciNome();
            product.Prezzo = InserisciPrezzo();
            product.Quantita = InserisciQuantita();

            return true;

        }



        public string InserisciNome()
        {
            Console.WriteLine("\nInserisci il nome del prodotto");
            string Nome = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(Nome) || (Nome is not string))
            {
                Console.WriteLine("\nInserisci un nome valido!");
                Nome = Console.ReadLine();
            }
            return Nome;
        }
        public decimal InserisciPrezzo()
        {
            decimal Prezzo = 0;
            try
            {

                Console.WriteLine("\nInserisci il prezzo del prodotto [Formato 00,00] :");
                Prezzo = Convert.ToDecimal(Console.ReadLine());


                while (Prezzo <= 0 || Prezzo == null || Prezzo > 1000)
                {
                    Console.WriteLine("\nInserisci un prezzo valido!");
                    Prezzo = Convert.ToDecimal(Console.ReadLine());
                }

            }
            catch (FormatException)
            {

                do
                {
                    try
                    {
                        Console.WriteLine("\nInserisci un prezzo valido!");
                        Prezzo = Convert.ToDecimal(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }
                    catch (OverflowException)
                    {

                    }

                } while (Prezzo <= 0 || Prezzo == null || Prezzo is string || Prezzo > 1000);
            }
            catch (OverflowException)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\nInserisci un prezzo valido!");
                        Prezzo = Convert.ToDecimal(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }
                    catch (OverflowException)
                    {

                    }


                } while (Prezzo <= 0 || Prezzo == null || Prezzo is string || Prezzo > 1000);

            }
            return Prezzo;
        }
        public int InserisciQuantita()
        {
            int Quantita = 0;

            try
            {

                Console.WriteLine("\nInserisci la quantità del prodotto :");
                Quantita = Convert.ToInt32(Console.ReadLine());

                while (Quantita <= 0 || Quantita == null || Quantita is decimal || Quantita > 100)
                {
                    Console.WriteLine("\nInserisci una quantità valida");
                    Quantita = Convert.ToInt32(Console.ReadLine());
                }

            }
            catch (FormatException)
            {
                do
                {

                    try
                    {

                        Console.WriteLine("\nInserisci una quantità valida");
                        Quantita = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }
                    catch (OverflowException)
                    {

                    }
                } while (Quantita <= 0 || Quantita == null || Quantita is string || Quantita is decimal || Quantita > 100);

            }
            catch (OverflowException)
            {
                do
                {

                    try
                    {

                        Console.WriteLine("\nInserisci una quantità valida");
                        Quantita = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }
                    catch (OverflowException)
                    {

                    }
                } while (Quantita <= 0 || Quantita == null || Quantita is string || Quantita is decimal || Quantita > 100);
            }
            return Quantita;
        }
        public int AddProductDescription(Product product, ICategoryRepository categoryRepository)
        {
            int IdCategoria = 0;
            //STAMPA TUTTE LE CATEGORIE DI PRODOTTI DISPONIBILI
            categoryRepository.GetProductsDescription();
            do
            {

                string mxs = "\nInserisci l' ID della categoria da assegnare al prodotto: ";
                IdCategoria = GetId(mxs);

                //SE NON TROVA ALCUNA CATEGORIA CON QUELL' ID FA RICHIEDRE L'ID UN' ALTRA VOLTA
            } while (!categoryRepository.GetProductDescriptionById(IdCategoria));

            return IdCategoria;
        }

        public bool MenuForUpdatingProduct(IProductRepository productRepository, ICategoryRepository categoryRepository,bool permanenza)
        {
            
            int IdProdottoModifica = 0;
            do
            {

                try
                {
                    Console.WriteLine("\nScegli cosa modificare:\n");
                    Console.WriteLine("1)Modifica prezzo prodotto\n2)Modifica prezzo e quantità del prodotto\n3)Modifica categoria prodotto\n4)Modifica l' intero prodotto\n5)Chiudi sezione modifica");
                    SceltaMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {

                }
                catch (OverflowException)
                {

                }

            } while (SceltaMenu <= 0 || SceltaMenu is string || SceltaMenu > 5);

            Product prodotto = new Product();
            
            switch (SceltaMenu)
            {
                case 1:
                    Console.WriteLine("  MODIFICA PREZZO  ");

                    prodotto.Prezzo = InserisciPrezzo();

                    productRepository.GetAllProducts();
                    do
                    {

                        IdProdottoModifica = GetId(mxs);

                    } while (!productRepository.UpdateProductByIdString(prodotto,IdProdottoModifica));


                    break;
                case 2:
                    Console.WriteLine("  MODIFICA PREZZO E QUANTITA'  ");
                    prodotto.Prezzo = InserisciPrezzo();
                    prodotto.Quantita = InserisciQuantita();

                    productRepository.GetAllProducts();

                    do
                    {

                        IdProdottoModifica = GetId(mxs);

                    } while (!productRepository.UpdateProductByIdString(prodotto,IdProdottoModifica));

                    break;
                case 3:
                    int IdCategoria = 0;
                    Console.WriteLine("  MODIFICA CATEGORIA PRODOTTO  ");
                    categoryRepository.GetProductsDescription();
                    do
                    {

                        string mxsCategory = "Inserisci l' Id della nuova categoria da assegnare al prodotto";
                        prodotto.Id_Categoria = GetId(mxsCategory);

                    } while (!categoryRepository.GetProductDescriptionById(prodotto.Id_Categoria));

                    productRepository.GetAllProducts();

                    do
                    {
                        IdProdottoModifica = GetId(mxs);

                    } while (!productRepository.UpdateProductByIdString(prodotto,IdProdottoModifica));




                    break;
                case 4:
                    Console.WriteLine("  MODIFICA L' INTERO PRODOTTO  ");
                   
                    prodotto.Nome = InserisciNome();
                    prodotto.Prezzo = InserisciPrezzo();
                    prodotto.Quantita = InserisciQuantita();

                    categoryRepository.GetProductsDescription();

                    do
                    {

                        string mxsCategory = "Inserisci l' Id della nuova categoria da assegnare al prodotto";
                        prodotto.Id_Categoria = GetId(mxsCategory);

                    } while (!categoryRepository.GetProductDescriptionById(prodotto.Id_Categoria));

                    productRepository.GetAllProducts();
                    do
                    {
                        IdProdottoModifica = GetId(mxs);

                    } while (!productRepository.UpdateProductByIdString(prodotto,IdProdottoModifica));

                    break;
                case 5:
                    Console.WriteLine("\nModifica terminata");
                     permanenza = false;
                    break;


            }

            return permanenza;

        }

        public int GetId(string mxs)
        {
            int Id = 0;
            do
            {
                try
                {
                    Console.WriteLine(mxs);
                    Id = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {

                }
                catch (OverflowException)
                {

                }

            } while (Id <= 0 || Id is string);


            return Id;
        }
    }
}
