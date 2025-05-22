// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Net.Http.Json;
using esercizio_parrucchiere;




List<Clienti> listaClienti = new List<Clienti>()
{
     new Clienti("Gabriele", "Cipriani", 20, "cipriani279@gmail.com", 3913720324,Clienti.Sesso.Maschio),
     new Clienti("Thomas", "Petaroscia", 22, "t.petaroscia@gmail.com", 3476589234,Clienti.Sesso.Maschio),
     new Clienti("Nicola", "Francavilla", 26, "n.francavilla@gmail.com", 3758945631,Clienti.Sesso.Maschio),
     new Clienti("Matteo", "Mennitti", 35, "m.mennitti@gmail.com", 333756328, Clienti.Sesso.Maschio),
     new Clienti("Lorenzo", "Coppola", 23, "l.coppola@gmail.com", 3812520384, Clienti.Sesso.Femmina),
     new Clienti("Francesco", "Caselli", 21, "f.caselli@gmail.com", 3182260226, Clienti.Sesso.Altro),
     new Clienti("Vincenzo", "Montagna", 31, "v.montagna@gmail.com", 3896461530, Clienti.Sesso.Femmina),
     new Clienti("Marco", "Perrelli", 20, "m.perrelli@gmail.com", 3714162621, Clienti.Sesso.Altro),
     new Clienti("Giuseppe", "Lategola", 20, "g.lategola@gmail.com", 3453510517, Clienti.Sesso.Maschio),
     new Clienti("Mauro", "Petruzzella", 43, "m.petruzzella@gmail.com", 3568975128, Clienti.Sesso.Femmina)

};
List<Servizi> listaServizi = new List<Servizi>()
{
    new Servizi("shampo capelli",5),
    new Servizi("balsamo capelli",3.50),
    new Servizi("taglio capelli",12),
    new Servizi("barba",7.20),
    new Servizi("taglio + shampo capelli su lettino relax",17.80),
    new Servizi("taglio + shampo capelli ",15.60),
    new Servizi("taglio+barba",12),
};

List<Prodotti> listaProdotti = new List<Prodotti>()
{
    new Prodotti("shampo capelli",5, 100),
    new Prodotti("balsamo capelli",5.50, 80),
    new Prodotti("cera capelli",3, 25),
    new Prodotti("gel capelli",12.99, 60),
    new Prodotti("spuma capelli ricci",8, 40),
    new Prodotti("lacca fissativa capelli",17.52, 180),
    new Prodotti("shampo2 capelli",8, 20),
};

List<Prodotti> listaScontrino = new List<Prodotti>();
Parrucchiere gigi = new Parrucchiere();
gigi.Clienti = listaClienti;
Scontrini gigi1 = new Scontrini();
gigi1.Prodotti = listaProdotti;
bool continua = true;
while (continua)
{
    Console.Write("quale operazione vuoi eseguire? \n" +
    "1)inserire nuovo cliente \n" +
    "2)stampa la lista clienti \n" +
    "3)rimuovere un cliente dalla lista \n" +
    "4)cercare le informazioni di un cliente \n" +
    "5)chiudere il programma\n" +
    "6)stampare la lista dei servizi\n");

    int numInserito = Convert.ToInt32(Console.ReadLine());
    if (numInserito >= 1 && numInserito <= 7)
    {
        switch (numInserito)
        {
            case 1:
                gigi.AddClient();
                break;
            case 2:
                gigi.PrintList();
                break;
            case 3:
                gigi.PrintList();
                gigi.DeleteClient();
                Console.WriteLine("cliente cancellato dalla lista con successo");
                gigi.PrintList();
                break;
            case 4:
                gigi.SearchClientInformations();
                break;
            case 5:
                Console.WriteLine("Programma terminato.");
                continua = false;
                break;
            case 6:
                gigi1.PrintListServices();
                break;
            case 7:
                var clientLinqTry = listaClienti.Where(c => c.Age > 20);
                foreach(var client in clientLinqTry) {  Console.WriteLine($"I clienti con più di 20 anni sono{client.FirstName}"); }
                break;
            default:
                Console.WriteLine("INSERIRE UN NUMERO CORRETTO");
                break;
        }
    }
}


