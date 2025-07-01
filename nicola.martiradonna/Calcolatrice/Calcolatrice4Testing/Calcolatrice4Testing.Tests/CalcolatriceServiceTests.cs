using Calcolatrice4Testing;
using Moq;
using AutoFixture;

namespace Calcolatrice4Testing.Tests
{
    public class CalcolatriceServiceTests
    {
        
        private readonly CalcolatriceService _serviceCalcolatrice= new CalcolatriceService();

        private readonly Mock<ICalcolatriceService>_mockCalcolatrice = new Mock<ICalcolatriceService>();
        
         
        [Fact]
        public void CalcolatriceService_Somma_Return10()
        {
            var num1 = 5;
            var num2 = 5;

            var somma = _serviceCalcolatrice.Somma(num1, num2);

            Assert.Equal(10, somma);
        }

        [Fact]
        public void CalcolatriceService_Differenza_Return5()
        {
            var num1 = 7;
            var num2 = 2;

            var differenza = _serviceCalcolatrice.Differenza(num1, num2);

            Assert.Equal(5, differenza);
        }
        
        [Fact]
        public void CalcolatriceService_Differenza_ThrowException()
        {
            var num1 = 3;
            var num2 = 5;

            Assert.Throws<DifferenceException>(() => _serviceCalcolatrice.Differenza(num1, num2));
        }

        [Fact]

        public void CalcolatriceService_Moltiplicazione_Return20()
        {
            var num1 = 5;
            var num2 = 4;

            var prodotto= _serviceCalcolatrice.Moltiplicazione(num1, num2);
            Assert.Equal(20, prodotto);
        }

        [Fact]

        public void CalcolatriceService_Divisione_Return3()
        {
            var num1 = 9;
            var num2 = 3;

            var quoziente = _serviceCalcolatrice.Divisione(num1, num2);
            Assert.Equal(3, quoziente);
        }

        [Fact]
        public void CalcolatriceService_Divisione_ThrowException()
        {
            var num1 = 9;
            var num2 = 0;

            Assert.Throws<DivisionException>(()=> _serviceCalcolatrice.Divisione(num1,num2));
        }
        
        [Theory]
        [InlineData(2,5)]
        public void CalcolatriceService_IsEven_ItsOK(double num1, double num2)
        {
            Assert.True(_serviceCalcolatrice.IsEven(num1));
            Assert.False(_serviceCalcolatrice.IsEven(num2));
            
        }



        [Fact]

        public void CalcolatriceService_Somma_Ritorna0Sempre()
        {


            _mockCalcolatrice.Setup(x => x.Somma(It.IsAny<double>(), It.IsAny<double>())).Returns(0);

            _mockCalcolatrice.Verify();

            var result= _mockCalcolatrice.Object.Somma(5, 4);
            var result1= _mockCalcolatrice.Object.Somma(7, 4);

            Assert.StrictEqual(0,result);
            Assert.StrictEqual(0, result1);


        }
        [Fact]
        public void CalcolatriceService_Differenza_Ritorna100Sempre()
        {


            _mockCalcolatrice.Setup(x => x.Differenza(5, 4)).Returns(100);

            _mockCalcolatrice.Verify();

            //Metodo con mock
            var result= _mockCalcolatrice.Object.Differenza(5, 4);

            //Metodo senza mock
            var result1= _serviceCalcolatrice.Differenza(8, 4);
            

            Assert.StrictEqual(100,result);
            Assert.StrictEqual(4, result1);
            Assert.Throws<DifferenceException>(() => _serviceCalcolatrice.Differenza(3, 4));


        }

        [Fact]
        public void CalcolatriceService_Moltiplicazione_Ritorna30Sempre()
        {


            _mockCalcolatrice.Setup(x => x.Moltiplicazione(It.IsAny<double>(), It.IsAny<double>())).Returns(30);

            _mockCalcolatrice.Verify();

            
            var result = _mockCalcolatrice.Object.Moltiplicazione(20, 4);
            var result1 = _mockCalcolatrice.Object.Moltiplicazione(70, 20.20);

            Assert.StrictEqual(30, result);
            Assert.StrictEqual(30, result1);
            
        }

        [Fact]
        public void CalcolatriceService_Divisione_Ritorna1Sempre()
        {

            _mockCalcolatrice.Setup(x => x.Divisione(100, 2)).Returns(1);

            _mockCalcolatrice.Verify();  


            var result = _mockCalcolatrice.Object.Divisione(100, 2);

            var result1 = _serviceCalcolatrice.Divisione(100, 2);

            Assert.StrictEqual(1, result);
            Assert.StrictEqual(50, result1);
            Assert.Throws<DivisionException>(() => _serviceCalcolatrice.Divisione(0, 2));

            


        }

    }
}