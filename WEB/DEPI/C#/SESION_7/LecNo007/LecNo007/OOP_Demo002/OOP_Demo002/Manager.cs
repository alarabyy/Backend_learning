using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo002
{
    public class Manager : Employee
    {
        // All Pubplic Memebres Inherited
        // All Protected Members Inherited
        // NO private Memeber SEEN

        public double Extra { get; set; }
        protected double GetExtra()
        {
            return 1000;
        }

        public sealed override double NetSalary()// to override MUST declared as a Virtual in base class
        {
            return Salary - Tax() + BonusValue();
        }
        new protected double Tax() // Hiding from CLR = NOT Recommended
        {
            return 500;
        }
    }
}
