using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_parrucchiere
{
    class Clienti
    {
        
        public string FirstName;
        public string LastName;     
        public int   Age;
        public string Email;
        public long PhoneNumber;

        public Clienti(string firstName, string lastName, int age, string email, long phoneNumber)
        {
          
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
        }


       


    }
}
