
using TestDelegate;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> list = new List<string>() { "antonio", "carlo", "vito", "mario" };

        string f = "Ciao";
        Console.WriteLine(f.IniziaPerA());
        list = MyWhere(IniziaPerA, list).ToList();

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    public static List<string> MyWhere(MyDelegateString CriterioDiSelezione, List<string> lista)
    {
        List<string> listaFiltrata = new List<string>();    
        foreach (var item in lista)
        {
            if (CriterioDiSelezione(item))
            { 
                listaFiltrata.Add(item);
            }

        }

        return listaFiltrata;
    }
    public static bool LunghezzaMaggioreDi5(string parola)
    {
        if(parola.Length > 5)
        {
            return true;
        }
        else 
        {
            return false;        
        }
    }

    public static bool IniziaPerA(string parola)
    {
        if (parola[0] == 'a' || parola[0] == 'A')
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

