using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
    internal class functions
    {
       
        public void Print2(List<Prodotti> magazzino)
        {
            foreach (var item in magazzino)//funzione scritta in Prodotti.cs
            {

                item.Print();

            }
        }

       
        public Prodotti? CercaProdotto(string nome, int quantita, List<Prodotti> magazzino)
        {
            foreach (Prodotti item in magazzino)
            {
                if (nome == item.NomeProdotto)
                {
                    return item;
                }

            }
            return null;

        }
        public void AggiungiProdotto(string nome, int quantita, List<Prodotti> magazzino)
        {
            Prodotti prodottoCercato= CercaProdotto(nome, quantita, magazzino);
            prodottoCercato.Quantita = prodottoCercato.Quantita + quantita;
        }


    }
}
