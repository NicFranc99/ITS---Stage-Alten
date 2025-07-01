namespace BarberApplication.utility
{
    using BarberApplication.@class;
    using BarberApplication.Interfaces;
    using System;
    using System.Security.Cryptography.X509Certificates;

    public class ClienteServizioService : IClienteServizioService
    {
        public IClienteServizioRepository Repository;
        public IClientService ClientUtility;
        public IServizioService ServizioUtility;

        public ClienteServizioService(
            IClienteServizioRepository repository,
            IClientService clientUtility,
            IServizioService servizioUtility)
        {
            Repository = repository;
            ClientUtility = clientUtility;
            ServizioUtility = servizioUtility;
        }

        public void AvviaOperazioni()
        {
            bool continua = true;
            while (continua)
            {

                Console.WriteLine("--------- Gestione Servizi per Cliente ---------\n" +
                    "1 - Associa un singolo servizio ad un cliente\n" +
                    "2 - Associa più servizi ad un cliente\n" +
                    "3 - Visualizza i servizi associati ad un cliente\n" +
                    "4 - Rimuovi un servizio associato ad un cliente\n" +
                    "0 - Esci\n");

                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        AssociaServizio();
                        break;
                    case "2":
                        AssociaMultipliServizi();
                        break;
                    case "3":
                        VisualizzaServiziCliente();
                        break;
                    case "4":
                        RimuoviServizio();
                        break;
                    case "0":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

                if (continua)
                {
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey();
                }
            }
        }


        
        public int OttieniIdClienteValido()
        {
            int clienteId;
            bool clienteEsistente = false;

           
            Console.WriteLine("\nElenco Clienti:");
            ClientUtility.GetAllClients();
           

            do
            {
                Console.Write("\nInserisci l'ID del cliente (0 per annullare): ");
                while (!int.TryParse(Console.ReadLine(), out clienteId))
                {
                    Console.Write("Valore non valido. Inserisci un numero: ");
                }
                if (clienteId == 0)
                {
                    Console.WriteLine("Operazione annullata dall'utente.");
                    return 0;
                }
                clienteEsistente = ClientUtility.GetClientsByID(clienteId);
                if (!clienteEsistente)
                {
                    Console.WriteLine("Cliente non trovato. Riprova.");
                }
            } while (!clienteEsistente);

            return clienteId;
        }

       
        private int OttieniIdServizioValido()
        {
            int servizioId;
            bool servizioEsistente = false;

            
            Console.WriteLine("\nElenco Servizi:");
            ServizioUtility.GetAllServizio();
            Console.WriteLine();

            do
            {
                Console.Write("Inserisci l'ID del servizio (0 per annullare): ");
                while (!int.TryParse(Console.ReadLine(), out servizioId))
                {
                    Console.Write("Valore non valido. Inserisci un numero: ");
                }
                if (servizioId == 0)
                {
                    Console.WriteLine("Operazione annullata dall'utente.");
                    return 0;
                }
                servizioEsistente = ServizioUtility.GetServizioByID(servizioId);
                if (!servizioEsistente)
                {
                    Console.WriteLine("Servizio non trovato. Riprova.");
                }
            } while (!servizioEsistente);

            return servizioId;
        }

        
        private void AssociaServizio()
        {
            int clienteId = OttieniIdClienteValido();
            if (clienteId == 0)
                return; 

            int servizioId = OttieniIdServizioValido();
            if (servizioId == 0)
                return; 

            Cliente_Servizio associazione = new Cliente_Servizio
            {
                ClienteId = clienteId,
                ServizioId = servizioId
            };

            if (Repository.AssociaServizio(associazione))
                Console.WriteLine("Servizio associato correttamente.");
            else
                Console.WriteLine("Errore durante l'associazione del servizio.");
        }

        
        private void AssociaMultipliServizi()
        {
            int clienteId = OttieniIdClienteValido();
            if (clienteId == 0)
                return;

            Console.WriteLine("Inserisci gli ID dei servizi da associare al cliente.");
            Console.WriteLine("Premi 0 al termine dell'inserimento.");

            bool almenoUnAssociazione = false;
            while (true)
            {
                int servizioId = OttieniIdServizioValido();
                if (servizioId == 0)
                    break;

                Cliente_Servizio associazione = new Cliente_Servizio
                {
                    ClienteId = clienteId,
                    ServizioId = servizioId
                };

                if (Repository.AssociaServizio(associazione))
                {
                    Console.WriteLine($"Servizio con ID {servizioId} associato correttamente al cliente {clienteId}.");
                    almenoUnAssociazione = true;
                }
                else
                {
                    Console.WriteLine($"Errore durante l'associazione del servizio con ID {servizioId}.");
                }
            }

            if (!almenoUnAssociazione)
            {
                Console.WriteLine("Nessun servizio è stato associato al cliente.");
            }
        }

     
        private void VisualizzaServiziCliente()
        {
            int clienteId = OttieniIdClienteValido();
            if (clienteId == 0)
                return;

            Cliente_Servizio operazione = new Cliente_Servizio { ClienteId = clienteId };

            if (!Repository.VisualizzaServizioPerCliente(operazione))
                Console.WriteLine("Nessun servizio associato oppure errore durante la visualizzazione.");
        }

        private void RimuoviServizio()
        {
           
            int clienteId = OttieniIdClienteValido();
            if (clienteId == 0)
                return;

            
            Console.WriteLine("\nServizi attualmente associati al cliente:");
            Cliente_Servizio operazioneVisualizza = new Cliente_Servizio { ClienteId = clienteId };
            bool haServizi = Repository.VisualizzaServizioPerCliente(operazioneVisualizza);
            if (!haServizi)
            {
                Console.WriteLine("Nessun servizio associato a questo cliente. Non è possibile procedere con la rimozione.");
                return;
            }

           
            int servizioId = OttieniIdServizioValido();
            if (servizioId == 0)
                return;

            Cliente_Servizio operazione = new Cliente_Servizio
            {
                ClienteId = clienteId,
                ServizioId = servizioId
            };

            if (!Repository.RemoveServizio(operazione))
                Console.WriteLine("Nessuna associazione trovata oppure errore nella rimozione.");
            
        }

    }

}
