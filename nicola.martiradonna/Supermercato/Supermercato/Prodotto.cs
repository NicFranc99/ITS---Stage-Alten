using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato
{
    class Prodotto
    {
        public enum Tipo
        {
            Salato,
            Dolce,
            Altro
        }

        public string NomeProdotto { get; set; }
        public double PrezzoProdotto { get; set; }

        public Tipo TipoProdotto { get; set; }
        public int Quantita { get; set; }

        public int QuantitaProdottoSalvata = 0;



        public void StampaProdotti(List<Prodotto> ListaProdotti)
        {
            
            foreach (var item in ListaProdotti)
            {

                Console.WriteLine(item.ToString());

            }
        }
        public override string ToString()
        {
            return $"{NomeProdotto} \t{PrezzoProdotto} euro \t Quantità {Quantita} \t TipoProdotto {TipoProdotto}";

        }


    }
}
