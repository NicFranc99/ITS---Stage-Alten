// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using cassa;


Prodotti prodotto1 = new Prodotti("Latte", 2.50,1 );
Prodotti prodotto2 = new Prodotti("Acqua", 0.50,1);
Prodotti prodotto3 = new Prodotti("Cereali",3.99, 1);
Prodotti prodotto4 = new Prodotti("Nutella", 3.70, 1);
Prodotti prodotto5 = new Prodotti("Burro", 1.90, 1);
Prodotti prodotto6 = new Prodotti("Yougurt", 2.70, 1);

List<Prodotti> magazzino = new List<Prodotti>()
{
    prodotto1, prodotto2, prodotto3, prodotto4, prodotto5, prodotto6
};
Supermercato supermercato = new Supermercato("Despar", "Via Lucarelli",magazzino);
supermercato.StampaSupermercato();

/*foreach (var item in Magazzino)
{
    item.Print();
}*/
Console.WriteLine("-------------------------------------- ");


bool condizione = true;
do
{
    Console.WriteLine("Selezionare un’operazione da eseguire: ");
    Console.WriteLine("1-Scontrino");
    Console.WriteLine("2-Stampa la lista dei prodotti ");
    Console.WriteLine("3-Inserisci un prodotto dalla lista ");
    Console.WriteLine("4-Termina programma");
    Console.WriteLine("inserisci la tua scelta: ");
    int sceltaUtente = Convert.ToInt32(Console.ReadLine());
    double scontrino = 0;
    //string prodottoDaScegliere;
    functions funzioni= new functions();
    string prodottoCercato;



    switch (sceltaUtente)
    {
        

        case 1:
            Console.WriteLine("Inserisci i prodotti:");
            while(true);
            {
                string prodottoScontrino= Console.ReadLine();
                listaScontrino.Add(prodottoScontrino);
                if (prodottoScontrino == "fine") break;

            } 
            break;

            //funzioni.Sum(magazzino);


        case 2:
            Console.WriteLine("La lista è la seguente:  ");

            funzioni.Print2(magazzino);
            Console.WriteLine("---------------------------------  ");
            break;
            
        case 3:
                Console.WriteLine("Inserire il nome del prodotto da caricare:  ");
                string prodotto = Console.ReadLine();
             Console.WriteLine("Inserire il numero:  ");
            int numProdottoDaScegliere = Convert.ToInt32(Console.ReadLine());
            funzioni.AggiungiProdotto(prodotto, numProdottoDaScegliere, magazzino);  
            


       

            Console.WriteLine("---------------------------------  ");

            break;
        case 4:
            Console.WriteLine("Chiusura programma");
            condizione = false;
            break;



    }
} while (condizione);

/*case 1:
            funzioni.Sum(magazzino);
            Console.WriteLine("lo scontrino è: " + scontrino);
            Console.WriteLine("---------------------------------  ");

            break;*/



