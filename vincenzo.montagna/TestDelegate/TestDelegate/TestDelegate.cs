using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegate
{
    public class TestDelegate
    {
        public static int EseguiOperazione(Func<int, int> op, int valore)
        {
            return op(valore);
        }
    }
}
