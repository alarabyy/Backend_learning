using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop18_inertance_system_projaect
{
    public class sales :Employee
    {

        public bool taskcompleted {  get; set; }
        public const decimal commission = 0.3m;

        public override decimal Calculate()
        {
            return base.Calculate() + bounus();

        }
        public  decimal bounus()
        {
            if (taskcompleted)
            {
                return commission * base.Calculate();
            }
            return 0;
        }


        public override string ToString()
            {
                return base.ToString() +
                       $"\taskcompleted:{(taskcompleted ? "yes" : "no")}" +
                       $"\nbounus:{bounus()}" +
                       $"\nnetsalary:{this.Calculate()}";
            }
        }
}
