using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop18_inertance_system_projaect
{
    public class Maintains :Employee
    {
        public const decimal hardship= 100m;

        public override decimal Calculate()
        {
            return base.Calculate() + hardship;

        }
      
        public override string ToString()
        {
            return base.ToString() +
                   $"\nhardship:{hardship}" +
                   $"\nnetsalary:{this.Calculate()}";
        }
    }
}
