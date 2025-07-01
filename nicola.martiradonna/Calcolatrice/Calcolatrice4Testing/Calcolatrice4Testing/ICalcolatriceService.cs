using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolatrice4Testing
{
    public interface ICalcolatriceService
    {
        public double Somma(double a, double b);

        public double Differenza(double a, double b);

        public double Moltiplicazione(double a, double b);

        public double Divisione(double a, double b);


        public bool IsEven(double num);
    }
}
