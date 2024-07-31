using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop9_events
{
    public class Stock
    {
        private string name;
        private decimal price;


        public event stockchangehandle onpricechange;
        public string Name => this.name;
        public decimal Price { get => this.price; set => this.price = value; }
        
        public Stock(string stdckname) 
        {
            this.name = stdckname;
        }

        public void changestock(decimal percent) 
        {
            decimal oldprice = this.price;
            this.price += Math.Round(this.price * percent, 2);
            if(onpricechange != null)
            {
                onpricechange(this, oldprice);
            }
        }
    }
}
