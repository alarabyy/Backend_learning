using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop3_method_overload
{
    public class localmethods
    {
        public static void paramven(int[] original)
        {

         foreach (int i in original)
            {
                if (iseven(i))
                {
                    Console.WriteLine($"num : {i} \n");
                }
            }

            bool iseven(int  num)
            {
               return num % 2 == 0;
            }
        }
    }
}
