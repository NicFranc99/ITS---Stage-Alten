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

    }
}
