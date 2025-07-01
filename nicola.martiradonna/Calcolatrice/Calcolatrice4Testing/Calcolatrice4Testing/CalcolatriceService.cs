using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calcolatrice4Testing
{
    public class CalcolatriceService: ICalcolatriceService
    {
        public double Somma(double a,double b)
        {
            return a + b;
        }

        public double Differenza(double a,double b)
        {
            if (a < b)
            {
                throw new DifferenceException("Il primo numero non può essere minore del secondo");
            }
            return a - b;
        }

        public double Moltiplicazione(double a,double b)
        {
            return a * b;
        }

        public double Divisione(double a,double b)
        {
           
                if (a == 0 || b == 0)
                {
                    throw new DivisionException("Non puoi dividere un numero per 0");

                }
            
            return a / b;
        }
        

        public bool IsEven(double num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
