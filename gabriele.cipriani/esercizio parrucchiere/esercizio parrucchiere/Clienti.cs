using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_parrucchiere
{
    class Clienti
    {
        public enum Sesso
        {
            Maschio = 0,
            Femmina = 1,
            Altro = 2
        }

        public string FirstName;
        public string LastName;     
        public int   Age;
        public string Email;
        public long PhoneNumber;
        public Sesso Sex;

        public Clienti(string firstName, string lastName, int age, string email, long phoneNumber,Sesso sex)
        {
          
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
            Sex = sex;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Age} {Email} {Email} {PhoneNumber} {Sex}";
        }

    }



}
