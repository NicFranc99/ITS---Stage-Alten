using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato_DB.Interfaces
{
    public interface  IProductService
    {

        bool AddProduct(Product product);

        int AddProductDescription(Product product, ICategoryRepository categoryRepository);

        bool MenuForUpdatingProduct(IProductRepository productRepository,ICategoryRepository categoryRepository,bool permanenza);

        int InserisciQuantita();

        decimal InserisciPrezzo();

        string InserisciNome();

        int GetId(string mxs);

        

    }
}
