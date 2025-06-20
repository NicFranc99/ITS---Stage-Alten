using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato
{
    class Scontrino
    {

        public double TotaleScontrino { get; set; }


        public List<Prodotto> ListaSpesa = new List<Prodotto>();

        public int OccorrenzaListaSpesa = 0;

        public bool prodottoTrovato = false;

        public string prodottoCercato;


        public void GeneraScontrino(List<Prodotto> ListaProdotti)
        {


            int sceltaUtente;


            do
            {
                do
                {

                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("\n\n1- Inserisci un prodotto nel carrello\n2- Stampa Scontrino\n3- Termina Operazione\n");
                    sceltaUtente = Convert.ToInt32(Console.ReadLine());


                } while (sceltaUtente != 1 && sceltaUtente != 2 && sceltaUtente != 3);



                switch (sceltaUtente)
                {
                    case 1:

                        Console.WriteLine("\n---------------------------------------\n");
                        Console.WriteLine("\nLista dei prodotti\n");

                        InserisciProdottoNelCarrello(ListaProdotti);

                        break;




                    case 2:



                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("\nScontrino generato\n");
                        Console.WriteLine("---------------------------------------\n\n");


                        PagaCarrello(ListaSpesa);

                        break;



                    case 3:

                        Console.WriteLine("\nOperazione terminata\n");

                        break;

                }

            } while (sceltaUtente == 1);

        }


        //---------------------------FUNZIONI-----------------------------------------
        public void InserisciProdottoNelCarrello(List<Prodotto> ListaProdotti)
        {
            int QuantitaProdottoInserita;

            int IndiceProdotto = 0;

            bool QuantitaSbagliata = false;


            foreach (var item in ListaProdotti)
            {
                Console.WriteLine($"{item.NomeProdotto} \t {String.Format("{0:0.00}", item.PrezzoProdotto)} euro \t\tQuantità prodotto:{item.Quantita} \t\tTipo prodotto:{item.TipoProdotto}");

            }

            do
            {
                prodottoTrovato = false;


                Console.WriteLine("\nSeleziona il prodotto che vuoi cercare\n");
                prodottoCercato = Console.ReadLine();


                //CICLO PER VEDERE SE E' PRESENTE UN PRODOTTO NELLA LISTA
                foreach (var item in ListaProdotti)
                {
                    if (prodottoCercato == item.NomeProdotto)
                    {

                        IndiceProdotto = ListaProdotti.IndexOf(item);

                        prodottoTrovato = true;

                    }
                }

            } while (prodottoTrovato == false);

            Console.WriteLine("\nProdotto Trovato");

            var ProdottoOccorrente = ListaProdotti[IndiceProdotto];


            if (ProdottoOccorrente.Quantita > 0)// VERIFICO SE LA QUANTITA' DEL PRODOTTO OCCORRENTE E' MAGGIORE DI 0
            {
                do
                {
                    QuantitaSbagliata = false;

                    do  //INSERISCO LA QUANTITA' DEL PRODOTTO CHE VOGLIO AGGIUNGERE AL CARRELLO
                    {

                        Console.WriteLine("\nInserisci quantità del prodotto\n");
                        QuantitaProdottoInserita = Convert.ToInt32(Console.ReadLine());

                    } while (QuantitaProdottoInserita <= 0);


                    if (QuantitaProdottoInserita > ProdottoOccorrente.Quantita)// VERIFICO SE LA QUANTITA' INSERITA DA TASTIERA SIA MINORE DELLA QUANTITA' DEL PRODOTTO RICHIESTO
                    {
                        Console.WriteLine("\nQuantità superiore inserita!!");
                        QuantitaSbagliata = true;

                    }
                    else
                    {


                        ProdottoOccorrente.Quantita = ProdottoOccorrente.Quantita - QuantitaProdottoInserita;

                        ProdottoOccorrente.QuantitaProdottoSalvata = ProdottoOccorrente.QuantitaProdottoSalvata + QuantitaProdottoInserita;


                        var NomeProdottoOccorrente = ProdottoOccorrente.NomeProdotto;



                        if (ListaSpesa.Any(l => l.NomeProdotto == ProdottoOccorrente.NomeProdotto))
                        {//VERIFICO SE NEL CARRELLO ESISTE UN PRODOTTO GIA' INSERITO IN PRECEDENZA DALL' UTENTE



                            var ProdottoDoppione = ListaSpesa.First(x => x.NomeProdotto == ProdottoOccorrente.NomeProdotto);

                            ProdottoDoppione.PrezzoProdotto = ProdottoOccorrente.PrezzoProdotto * ProdottoOccorrente.QuantitaProdottoSalvata;


                        }
                        else
                        {//INSERISCO IL PRODOTTO CON LA SUA QUANTITA' SE NON E' GIA' STATO INSERITO NEL CARRELLO IN PRECEDENZA
                            Prodotto prodotto = new()
                            {
                                NomeProdotto = ProdottoOccorrente.NomeProdotto,
                                PrezzoProdotto = ProdottoOccorrente.PrezzoProdotto,
                                Quantita = ProdottoOccorrente.Quantita
                            };

                            ListaSpesa.Add(prodotto);



                            ListaSpesa[OccorrenzaListaSpesa].PrezzoProdotto = ListaSpesa[OccorrenzaListaSpesa].PrezzoProdotto * QuantitaProdottoInserita;


                            OccorrenzaListaSpesa++;
                        }


                    }

                } while (QuantitaSbagliata == true);


                Console.WriteLine("\nProdotto inserito con successo nel carrello\n");

            }//CHIUSURA IF
            else
            {
                Console.WriteLine("\nNon puoi richiedere questo prodotto perchè è finito");

            }
        }




        public void PagaCarrello(List<Prodotto> ListaSpesa)
        {

            var ProdottiListaSpesa = ListaSpesa.Select(prodotto => $"{prodotto.NomeProdotto} {String.Format("{0:0.00}", prodotto.PrezzoProdotto)} Euro ").ToList();

            var TotaleLista = ListaSpesa.Sum(prodotto => prodotto.PrezzoProdotto);

            foreach (var Prodotti in ProdottiListaSpesa)
            {
                Console.WriteLine(Prodotti);
            }

            Console.WriteLine("---------------------------------------\n");
            Console.WriteLine($"Il Totale è: {String.Format("{0:0.00}", TotaleLista)} Euro");


        }


    }
}
