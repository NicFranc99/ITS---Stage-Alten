using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercato_DB.Repos;

namespace Supermercato_DB.Tests
{
    public class ProductRepositoryTests
    {
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository();
        }

        [Fact]
        public void ProductRepository_CreateNewProduct_ReturnTrue()
        {
            
            var product = new Product()
            {
                Nome = "Saikebon manzo",
                Prezzo = 2.50m,
                Quantita = 5,
                Id_Categoria = 1

            };

            

            var result = _productRepository.CreateNewProduct(product);

            Assert.True(result);
        }

        [Fact]

        public void ProductRepository_CreateNewProduct_Empty()
        {

            var product = new Product();

           

            var result = _productRepository.CreateNewProduct(product);

            Assert.False(result);
        }

        [Fact]
        public void ProductRepository_CreateNewProduct_NotExistingIdCategory()
        {
            
            var product = new Product()
            {

                Nome = "pippo",
                Prezzo = 3.30m,
                Quantita = 3,
                Id_Categoria=10
            };

            

            var result = _productRepository.CreateNewProduct(product);

            Assert.False(result);

        }

        [Fact]

        public void ProductRepository_GetProductById_ValidId()
        {
            

            int id = 20;

            var result = _productRepository.GetProductById(id);

            Assert.True(result);

        }

        [Fact]
        public void ProductRepository_GetProductById_InvalidId()
        {
            var productRepo = new ProductRepository();
            
            int id = 100;

            var result = productRepo.GetProductById(id);

            Assert.False(result);

        }

        [Theory]
        [InlineData(3,20)]
        public void ProductRepository_IsProductQuantityAvaible_Avaible(int quantity, int id)
        {
         

            var result = _productRepository.IsProductQuantityAvaible(id, quantity);

            Assert.True(result);
        }

        [Theory]
        [InlineData(5,20)]
        public void ProductRepository_IsProductQuantityAvaible_NotAvaible(int quantity,int id)
        {
            
            var result = _productRepository.IsProductQuantityAvaible(id, quantity);

            Assert.False(result);
             
        }

        

    }
}
