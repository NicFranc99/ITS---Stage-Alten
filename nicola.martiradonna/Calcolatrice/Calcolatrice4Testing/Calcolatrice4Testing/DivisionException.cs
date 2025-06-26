using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolatrice4Testing
{
    public class DivisionException:Exception
    {
        public DivisionException(string mxs) :base(mxs)  { }
    }
}
