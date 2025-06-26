using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato_DB
{
    public class Product
    {
        public int Id { get; set; }
        public string ?Nome { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
        public int Id_Categoria {  get; set; }

    }
}
