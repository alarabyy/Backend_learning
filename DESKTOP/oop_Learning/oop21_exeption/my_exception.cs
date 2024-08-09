using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop21_exeption
{
    public class my_exception : Exception
    {
        public override string Message 
        {
            get{ return "empty exception..............."; }
        }
    }
}
