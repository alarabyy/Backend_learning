using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop18_inertance_system_projaect
{
    public class Developer : Employee
    {
        public const decimal allowance = 0.05m;

        public override decimal Calculate()
        {
            return base.Calculate() + calculateallowance();

        }
        private decimal calculateallowance()
        {
            return allowance * base.Calculate();
        }
        public override string ToString()
        {
            return base.ToString() +
                   $"\nallowance:{calculateallowance()}" +
                   $"\nnetsalary:{this.Calculate()}";
        }
    }
}
