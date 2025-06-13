using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato_DB
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }



        public bool InserisciNuovoProdotto()
        {
            InserisciNomeProdotto();

            InserisciPrezzoProdotto();

            InserisciQuantitaProdotto();

            return true;

        }

        public void InserisciNomeProdotto()
        {
            Console.WriteLine("\nInserisci il nome del prodotto");
            Nome = Console.ReadLine();

            while (Nome == "")
            {
                Console.WriteLine("\nInserisci un nome valido!");
                Nome = Console.ReadLine();
            }

        }
        public void InserisciPrezzoProdotto()
        {
            try
            {

                Console.WriteLine("\nInserisci il prezzo del prodotto [Formato 00,00] :");
                Prezzo = Convert.ToDecimal(Console.ReadLine());


                while (Prezzo <= 0 || Prezzo == null || Prezzo is string)
                {
                    Console.WriteLine("\nInserisci un prezzo valido!");
                    Prezzo = Convert.ToDecimal(Console.ReadLine());
                }

            }
            catch (FormatException)
            {

                while (Prezzo <= 0 || Prezzo == null || Prezzo is string)
                {
                    try
                    {
                        Console.WriteLine("\nInserisci un prezzo valido!");
                        Prezzo = Convert.ToDecimal(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }

                }
            }
        }
        public void InserisciQuantitaProdotto()
        {
            try
            {

                Console.WriteLine("\nInserisci la quantità del prodotto :");
                Quantita = Convert.ToInt32(Console.ReadLine());

                while (Quantita <= 0 || Quantita == null || Quantita is string || Quantita is decimal)
                {
                    Console.WriteLine("\nInserisci una quantità valida");
                    Quantita = Convert.ToInt32(Console.ReadLine());
                }

            }
            catch (FormatException)
            {
                while (Quantita <= 0 || Quantita == null || Quantita is string || Quantita is decimal)
                {
                    try
                    {
                        Console.WriteLine("\nInserisci una quantità valida");
                        Quantita = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }
                }
            }
        }
    }
}
