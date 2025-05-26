using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegate
{
    public static class EstensioniStringa
    {
        public static bool IniziaPerA(this string s)
        {
            if (s[0] == 'a' || s[0] == 'A' )
            {  
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
