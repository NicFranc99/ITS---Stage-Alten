using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
     class Prodotti
    {
        
        
            public string NomeProdotto;
            public double Prezzo;
        public int Quantita;
        
        

            public Prodotti(string nomeProdotto, double prezzo,int quantita)
            {
                NomeProdotto = nomeProdotto;
                Prezzo = prezzo;
                Quantita = quantita;
            }
            public void Print()
            {
                Console.WriteLine(NomeProdotto + " " + Prezzo + " " + Quantita);
            }
        

    }

}
