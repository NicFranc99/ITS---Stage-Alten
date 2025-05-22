using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassa
{
    internal class Scontrino
    {
        public double PrezzoTotale;
        
        public List<Prodotti> ListaScontrino;
        

        public Scontrino()
        {
            PrezzoTotale = 0;
            ListaScontrino = new List<Prodotti>();

        }

        public void AggiungiProdotto( string nome, List<Prodotti> magazzino)
        {
            functions funzioni = new functions();
            prodottoScontrino= funzioni.CercaProdotto(magazzino, nome);
                }
        
    }
}
