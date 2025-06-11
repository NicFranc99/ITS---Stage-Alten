
using Supermercato;

Prodotto prodotto = new Prodotto();

Prodotto nutella = new Prodotto("Nutella", 4.50, Prodotto.Tipo.Dolce, 2);
Prodotto latteGranarolo = new Prodotto("Latte Granarolo", 3.50, Prodotto.Tipo.Altro, 3);
Prodotto cartaIgenicaScottex = new Prodotto("Carta Igenica Scottex", 2.00, Prodotto.Tipo.Altro, 2);
Prodotto pennetteBarilla = new Prodotto("Pennette Barilla", 1.20, Prodotto.Tipo.Salato, 5);



Magazzino magazzino = new Magazzino();
magazzino.CaricaMagazzino(nutella, latteGranarolo, cartaIgenicaScottex, pennetteBarilla);




Scontrino scontrino = new Scontrino();


int sceltaUtente;

do
{
    do
    {
        Console.WriteLine("\nSelezionare un’operazione da eseguire");
        Console.WriteLine("1 - Scontrino");
        Console.WriteLine("2 – Stampa la lista dei prodotti");
        Console.WriteLine("3 – Linq");
        Console.WriteLine("4 – Termina programma");


        sceltaUtente = Convert.ToInt32(Console.ReadLine());


        if (sceltaUtente != 1 && sceltaUtente != 2 && sceltaUtente != 3 && sceltaUtente != 4)
        {
            Console.WriteLine("Numero non supportato - riprovare\n");
        }


    } while (sceltaUtente != 1 && sceltaUtente != 2 && sceltaUtente != 3 && sceltaUtente != 4);




    switch (sceltaUtente)
    {
        case 1:

            scontrino.GeneraScontrino(magazzino.ListaProdotti);


            break;


        case 2:

            Console.WriteLine("\nLista dei prodotti\n");
            prodotto.StampaProdotti(magazzino.ListaProdotti);

            break;


        case 3:
            Console.WriteLine("Inserisci il nome del prodotto");
            string nomeProdotto=Console.ReadLine();

            Console.WriteLine("Inserisci il prezzo");
            double prezzo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Inserisci la quantità");
            int quantita = Convert.ToInt32(Console.ReadLine());

            Prodotto prodottoNuovo = new Prodotto(nomeProdotto,prezzo,quantita,Prodotto.Tipo.Salato);
            prodottoNuovo.QuantitaProdottoSalvata = 100;

            Console.WriteLine($"{prodottoNuovo.NomeProdotto} {prodottoNuovo.PrezzoProdotto} {prodottoNuovo.Quantita} {prodottoNuovo.TipoProdotto} {prodottoNuovo.QuantitaProdottoSalvata}");

            //var ProdottiOrdinatiPrezzo = ListaProdotti.Where(l=> l.PrezzoProdotto>1.20).Select(l => l.NomeProdotto);

            //foreach(var prezzo in ProdottiOrdinatiPrezzo)
            //{
            //    Console.WriteLine($"Nome Prodotto {prezzo}");
            //}

            //var ProdottiOrdinatiPerQuantitaCrescente= ListaProdotti.Where(l=> l.Quantita>2).Select(l=>$"{l.NomeProdotto} {l.Quantita}");

            //foreach(var prodotti in ProdottiOrdinatiPerQuantitaCrescente)
            //{
            //    Console.WriteLine(prodotti);
            //}

            break;
        case 4:
            Console.WriteLine("Chiusura Programma");
            break;
    }


} while (sceltaUtente == 1 || sceltaUtente == 2 || sceltaUtente == 3);





