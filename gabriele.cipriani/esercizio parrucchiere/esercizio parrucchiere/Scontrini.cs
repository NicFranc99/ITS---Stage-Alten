using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_parrucchiere
{
    class Scontrini
    {
        public List<Servizi> Servizi;
        public List<Prodotti> Prodotti;
        public void PrintListServices()
        {
            int i = 0;
            foreach (Servizi servizio in Servizi)
            {
                i++;
                Console.WriteLine($"{i}) {servizio.Name} {servizio.Price} ");

            }


        }
        public void PrintListProducts()
        {
            int i = 0;
            foreach (Prodotti prodotto in Prodotti)
            {
                i++;
                Console.WriteLine($"{i}) {prodotto.Name} {prodotto.Price} {prodotto.Quantity} ");

            }


        }

        public void AddToReceipt()
        {
            Console.WriteLine("inserisci nome prodotto");
            string nomeProdotto=Console.ReadLine();
            Console.WriteLine("inserisci la quantità da comprare");
            int quantità = Convert.ToInt32(Console.ReadLine());
            Scontrini prodottoTastiera = new Scontrini();
            
            Console.WriteLine("Cliente aggiunto alla lista");

        }






        public void DoReceipt()
        {
            Console.WriteLine("premi 1 per aggiungere un prodotto al carrello\n" +
                "premi 2 per terminare");
            int numInserito = Convert.ToInt32(Console.ReadLine());
            if (numInserito >= 1 && numInserito <= 2)
            {
                switch (numInserito)
                {
                    case 1:
                      
                    default:
                        Console.WriteLine("INSERIRE UN NUMERO CORRETTO");
                        break;
                }
            }
        }

    }













}

