using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop5_properties
{
    public class Dollar
    {
        private decimal _amount;

        public decimal Amount   //properties
        {
            get { return this._amount; }
            set { this._amount = Processvalue(value); }
        }

        public Dollar(decimal amount)
        {
            this._amount = Processvalue(amount);
        }

        public Dollar()
        {
        }

        public decimal Processvalue(decimal value) => value <= 0 ? 0 : Math.Round(value, 2);
    }
}
