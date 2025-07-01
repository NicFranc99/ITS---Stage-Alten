using FluentAssertions;
using Moq;
using Supermercato_DB.Interfaces;
using Supermercato_DB.Repos;
using Supermercato_DB.Services;
using Xunit;

namespace Supermercato_DB.Tests
{
    public class ProductServiceTests
    {

        private readonly ProductService _productService= new ProductService();



        [Fact]
        public void ProductService_InserisciCountry_ThrowsException()
        {
            int? num=null;
            var productService= new ProductService();

            Assert.Throws<ArgumentNullException>(() => productService.InserisciNumero(num));
        }   

        [Fact]
        public void ProductService_InserisciCountry_NoThrowsException()
        {
            int? num = 4;
            var productService = new ProductService();

            Assert.NotNull(productService.InserisciNumero(num));
        }

        [Fact]
       public void Product_Service_AddProduct_AddngWithMock()
        {
            var mockProductService= new Mock<IProductService>();

            var prodotto = new Product();
            mockProductService.Setup(x => x.InserisciNome(It.IsAny<string>())).Returns("Nome1");
            mockProductService.Setup(x => x.InserisciPrezzo(It.IsAny<decimal>())).Returns(3.30m);
            mockProductService.Setup(x => x.InserisciQuantita(It.IsAny<int>())).Returns(2);

            var result1= mockProductService.Object.AddProduct(prodotto);

            var result2 = mockProductService.Object.InserisciNome("d");
            var result3 = mockProductService.Object.InserisciPrezzo(2.20m);
            var result4 = mockProductService.Object.InserisciQuantita(3);

            Assert.Equal("Nome1", result2);
            Assert.StrictEqual(3.30m, result3);
            Assert.StrictEqual(2, result4);
           


        }

        
    }
}
