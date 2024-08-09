using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop18_inertance_system_projaect
{
    public class Employee
    {
        public const int Minimumloggedhoures = 176;
        public const decimal overtime = 1.25m;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Loggedhour { get; set; }
        public decimal Wave { get; set; }

        public virtual decimal Calculate()
    {

            return calculateovertime() + calculatesalary();
    }

        private decimal calculatesalary()
        {
            return Wave * Loggedhour;
        }
        private decimal calculateovertime()
        {
            var additionhoure = ((Loggedhour - Minimumloggedhoures) > 0 ? Loggedhour - Minimumloggedhoures : 0);
            return (additionhoure * Wave * overtime);
        }
        public override string ToString()
        {
        var type = GetType().ToString().Replace("oop18_inertance_system_projaect","");

            return $"\n{type}" +
                   $"\nid: {Id}" +
                   $"\nname: {Name}" +
                   $"\nlogedhoure: {Loggedhour}" +
                   $"\nwave: {Wave}" +
                   $"\nbasesalary:{Math.Round(calculatesalary(),2):N0}" +
                   $"\novertime: {calculateovertime()}";
        }
    }
}
