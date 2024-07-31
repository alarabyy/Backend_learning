using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop3_method_overload
{
    public class overload
    {
        //=========================================================================
        //over load
        public void trip(int money)
        {
            Console.WriteLine($"money: {money}");
        }
        public void trip(int money ,string hotel)
        {
            Console.WriteLine($"money: {money} and hotel {hotel}");
        }
        public void trip(int money, string hotel , string bus)
        {
            Console.WriteLine($"money: {money} and hotel {hotel} with {bus}");
        }



        //=========================================================================
        //arrow method
        public bool iseven(int num) => num % 2 == 0;
       

    }
}
