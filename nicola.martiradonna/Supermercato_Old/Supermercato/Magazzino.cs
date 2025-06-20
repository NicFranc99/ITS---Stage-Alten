using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato
{
    class Magazzino
    {
        public List<Prodotto> ListaProdotti = new List<Prodotto>();



        public void CaricaMagazzino(Prodotto nutella, Prodotto latteGranarolo, Prodotto cartaIgenicaScottex, Prodotto pennetteBarilla)
        {
            ListaProdotti.Add(nutella);
            ListaProdotti.Add(latteGranarolo);
            ListaProdotti.Add(cartaIgenicaScottex);
            ListaProdotti.Add(pennetteBarilla);
        }
    }
}
