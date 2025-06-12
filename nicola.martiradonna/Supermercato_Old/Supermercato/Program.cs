
using Supermercato;

Prodotto prodotto = new Prodotto();

Prodotto nutella = new Prodotto()
{
    NomeProdotto = "Nutella",
    PrezzoProdotto = 4.50,
    TipoProdotto = Prodotto.Tipo.Dolce,
    Quantita = 2

};

Prodotto latteGranarolo = new Prodotto()
{
    NomeProdotto = "Latte Granarolo",
    PrezzoProdotto = 3.50,
    TipoProdotto = Prodotto.Tipo.Altro,
    Quantita = 3
};

Prodotto cartaIgenicaScottex = new Prodotto()
{
    NomeProdotto = "Carta Igenica Scottex",
    PrezzoProdotto = 2.00,
    TipoProdotto = Prodotto.Tipo.Altro,
    Quantita = 2
};

Prodotto pennetteBarilla = new Prodotto()
{
    NomeProdotto = "Pennette Barilla",
    TipoProdotto = Prodotto.Tipo.Salato,
    PrezzoProdotto = 1.20,
    Quantita = 5
};

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





