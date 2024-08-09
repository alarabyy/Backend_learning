using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop10_operateroverloading
{
    public class money
    {
        private decimal amount;
        public decimal Amount => amount;

        public money(decimal value)
        {
            this.amount = Math.Round(value , 2);
        }
        public static money operator +(money m1, money m2)
        {
            var resulte = m1.amount + m2.amount;
            return new money(resulte);
        }
        public static money operator -(money m1, money m2)
        {
            var resulte = m1.amount - m2.amount;
            return new money(resulte);
        }
        public static money operator *(money m1, money m2)
        {
            var resulte = m1.amount * m2.amount;
            return new money(resulte);
        }
        public static money operator /(money m1, money m2)
        {
            var resulte = m1.amount / m2.amount;
            return new money(resulte);
        }
   
    }
}
