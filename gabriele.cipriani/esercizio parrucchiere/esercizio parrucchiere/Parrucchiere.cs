using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_parrucchiere
{
    class Parrucchiere
    {
        public List<Clienti> Clienti;

        public void PrintList()
        {
            int i = 0;
                foreach (Clienti cliente in Clienti)
                {
                    i++;
                    Console.WriteLine($"{i}) {cliente.ToString()}");
                   
                }

           
        }
       







        public void AddClient()
        {
            int age = 0;
            
          
            Console.WriteLine("inserisci nome cliente");
            string firstName = Console.ReadLine();
            Console.WriteLine("inserisci cognome cliente");
            string lastName = Console.ReadLine();
            Console.WriteLine("inserisci l'età");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("inserisci la mail");
            string email = Console.ReadLine();
            Console.WriteLine("inserisci il numero di telefono");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            
            Clienti clienteTastiera = new Clienti(firstName, lastName, age, email, phoneNumber, esercizio_parrucchiere.Clienti.Sesso.Maschio);
           // clienteTastiera.Sex = Clienti.Sesso.Maschio;
            Clienti.Add(clienteTastiera);
            Console.WriteLine("Cliente aggiunto alla lista");


        }

        public void DeleteClient()
        {
            int numeroInserito = 0;


            do
            {
                Console.WriteLine("inserisci l'id della persona da cancellare dalla lista");
                //numeroInserito = Convert.ToInt32(Console.ReadLine());
                //numeroInserito = int.Parse(Console.ReadLine());
                int.TryParse(Console.ReadLine(), out numeroInserito);



            } while (numeroInserito > Clienti.Count);

            Clienti.RemoveAt(numeroInserito-1);



        }

        public void SearchClientInformations()
        {
            bool trovato = true;
            while (trovato) 
            {
                Console.WriteLine("Inserisci il nome del cliente:");
                string nomeRicerca = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome del cliente:");
                string cognomeRicerca = Console.ReadLine();


                Clienti clienteTrovato = null;
                foreach (Clienti cliente in Clienti)
                {
                    if (cliente.FirstName.Equals(nomeRicerca, StringComparison.OrdinalIgnoreCase) && cliente.LastName.Equals(cognomeRicerca, StringComparison.OrdinalIgnoreCase))
                    {
                        clienteTrovato = cliente;
                        break;
                    }
                }


                if (clienteTrovato != null)
                {
                    Console.WriteLine($"Informazioni del cliente trovato: {clienteTrovato.Age},{clienteTrovato.Email},{clienteTrovato.PhoneNumber}");
                    trovato = false;
                }
                else
                {
                    Console.WriteLine($"Spiacente non ho trovato nessun cliente con {nomeRicerca} e {cognomeRicerca}. Riprovare..”");
                  
                }
            } 
        }
    }
}
    

