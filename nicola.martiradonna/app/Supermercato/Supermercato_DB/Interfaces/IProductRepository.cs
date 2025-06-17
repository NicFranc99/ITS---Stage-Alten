using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato_DB.Interfaces
{
    public interface IProductRepository
    {
        bool GetAllProducts();

        bool GetProductById(int id);


        bool CreateNewProduct(Product product,int IdDescription);
        //INSERISCE UN NUOVO PRODOTTO


        bool IsProductQuantityAvaible(int id,int quantita);
        //VERIFICA SE LA DIFFERENZA TRA LA QUANTITA' DEL PRODOTTO INSERITA DALL' UTENTE E' MINORE RISPETTO A QUELLA SUL DB
        bool UpdateProductQuantity(int id,int quantita);
        //AGGIORNA LA QUANTITA' DEL PRODOTTO
        Product AddProductToTheCart(int id,Product prodottoCarrello);
        //AGGIUNGE ALL' OGGETTO ISTANZIATO PRODOTTO I VALORI PRESENTI NEL DB ASSEGNANDO ANCHE IL PREZZO IN BASE ALLA QUANTITA'



    }
}
