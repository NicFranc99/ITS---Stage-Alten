using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_parrucchiere
{
    internal class Prodotti
    {
        public string Name;
        public double Price;
        public int Quantity;
       

        public Prodotti(string name, double price, int quantity)
        {

            Name = name;
            Price = price;
            Quantity = quantity;
           
        }

    }
}
