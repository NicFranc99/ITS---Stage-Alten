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

        public Prodotto(string NomeProdotto, double PrezzoProdotto, Tipo TipoProdotto, int Quantita)
        {
            this.NomeProdotto = NomeProdotto;
            this.PrezzoProdotto = PrezzoProdotto;
            this.TipoProdotto = TipoProdotto;
            this.Quantita = Quantita;
        }

        public Prodotto(string NomeProdotto,double PrezzoProdotto,int Quantita,Tipo TipoProdotto)
        {
            this.NomeProdotto= NomeProdotto;
            this.PrezzoProdotto= PrezzoProdotto;
            this.Quantita=Quantita;
            this.TipoProdotto=TipoProdotto;
        }

       
        

        public Prodotto()
        {

        }

        public void StampaProdotti(List<Prodotto> ListaProdotti)
        {
            
            foreach (var item in ListaProdotti)
            {

                Console.WriteLine(item.ToString());

            }
        }
        public override string ToString()
        {
            return $"{NomeProdotto}\t{PrezzoProdotto} euro \t Quantità {Quantita}\t TipoProdotto {TipoProdotto}";

        }


    }
}
