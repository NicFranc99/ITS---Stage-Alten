using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercato_DB.Interfaces;

namespace Supermercato_DB
{
    public class Scontrino
    {
        public decimal TotaleScontrino { get; set; }

        public List<Product> ListaSpesa = new List<Product>();
        public bool Menu(IProductRepository productRepository)
        {
            do
            {
                int sceltaUtente = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("\n1) Inserisci un prodotto nel carrello\n2) Stampa Scontrino\n3) Esci ");
                        sceltaUtente = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }

                } while (sceltaUtente < 1 || sceltaUtente > 3 || sceltaUtente is string);


                switch (sceltaUtente)
                {
                    case 1:
                        //INSERISCE UN NUOVO PRODOTTO NEL CARRELLLO
                        InserisciProdottoNelCarrello(productRepository);
                        break;
                    case 2:
                        //CALCOLA IL TOTALE DELLO SCONTRINO
                        CalcolaTotale();

                        break;
                    case 3:

                        Console.WriteLine("\n Scontrino terminato  ");
                        return false;

                }

            } while (true);

        }

        public void InserisciProdottoNelCarrello(IProductRepository productRepository)
        {

            productRepository.GetAllProducts();
           
            int QuantitàTastiera = 0;
            int IdProdottoCarrello = 0;
            
                //FUNZIONE PER VERIFICARE SE L'ID INSERITO DA TASTIERA CORRISPONDE AD UN PRODOTTO PRESENTE NEL DB
                 IdProdottoCarrello= VerificaIdProdottoDB(productRepository);
            do
            {
                do
                {

                    try
                    {
                        Console.WriteLine("Inserisci la quantità del prodotto");
                        QuantitàTastiera = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        do
                        {
                            Console.WriteLine("Quantità non valida");
                            Console.WriteLine("Inserisci la quantità del prodotto");
                            QuantitàTastiera = Convert.ToInt32(Console.ReadLine());
                        } while (QuantitàTastiera <= 0 || QuantitàTastiera is string);
                    }

                } while (QuantitàTastiera <= 0 || QuantitàTastiera is string);

                

                //SE LA QUANTITA' INSERITA NON E' DISPONIBILE PER QUEL PRODOTTO FA REINSERIRE LA QUANTITA'
            } while (!productRepository.IsProductQuantityAvaible(IdProdottoCarrello, QuantitàTastiera));
            
            //AGGIORNA LA QUANTITA' SUL DB 
            productRepository.UpdateProductQuantity(IdProdottoCarrello, QuantitàTastiera);

            Product prodottoCarrello = new Product();

            prodottoCarrello.Quantita = QuantitàTastiera;
            

            //AGGIUNGO ALLA LISTA DELLA SPESA IL PRODOTTO SELEZIONATO CON LA SUA QUANTITA'
            ListaSpesa.Add(productRepository.AddProductToTheCart(IdProdottoCarrello,prodottoCarrello));


            Console.WriteLine("Prodotto inserito nel carrello con successo");

        }
        public int VerificaIdProdottoDB(IProductRepository productRepository)
        {
            int IdProdottoCarrello = 0;
            do
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\nInserisci l' ID del prodotto da inserire nel carrello: ");
                        IdProdottoCarrello = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                    }
                } while (IdProdottoCarrello <= 0 || IdProdottoCarrello is string);

            } while (!productRepository.GetProductById(IdProdottoCarrello));

            return IdProdottoCarrello;
        }

        public void CalcolaTotale()
        {
            var ProdottiListaSpesa = ListaSpesa.Select(prodotto => $"{prodotto.Nome} {String.Format("{0:0.00}", prodotto.Prezzo)} euro ").ToList();
            var Totale = ListaSpesa.Sum(prodotto => prodotto.Prezzo);

            foreach (var prodotti in ProdottiListaSpesa)
            {
                Console.WriteLine($"\n{prodotti}");

            }
            Console.WriteLine("\n---------------------------------------\n");
            Console.WriteLine($"Il Totale è: {String.Format("{0:0.00}", Totale)} euro");
        }
    }
}
