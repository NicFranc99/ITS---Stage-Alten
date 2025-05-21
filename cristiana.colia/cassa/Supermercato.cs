using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
    class Supermercato
    {
        public string Nome;
        public string Via;
        public List<Prodotti> ProdottiList;

        public Supermercato(string nome, string via,List<Prodotti> prodottiList)
        {
            Nome = nome;
            Via = via;
            ProdottiList= prodottiList;
        }
        public void Stampa()
        {
            Console.WriteLine(Nome);
            Console.WriteLine(Via);
            Console.WriteLine(ProdottiList);
        }
        public void StampaSupermercato()
        {
            Console.WriteLine(Nome + " " + Via);
        }
        

        //Creare metodo EsisteProdotto(string): bool
    }

}
/*foreach (var item in magazzino)
{
    if (item.NomeProdotto == prodottoDaScegliere)
    {
        item.Quantita = item.Quantita + numProdottoDaScegliere;
    }
}*/
