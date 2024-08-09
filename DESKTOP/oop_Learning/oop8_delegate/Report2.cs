using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop88_delegate
{
    public class Report
    {

        public delegate bool prcessindde(Employee2 employee);

        public void processes(Employee2[] employee, string title, prcessindde prcessindde)
        {
            Console.WriteLine(title);
            Console.WriteLine("================");

            foreach (var x in employee)
            {
                if (prcessindde(x))
                {
                    Console.WriteLine($"{x.Id} | {x.FirstName} | {x.LastName} | {x.Gender} | {x.salary}");
                }
                Console.WriteLine("===============================");
            }
            Console.WriteLine("============================================================\n");



        }




    }
}
