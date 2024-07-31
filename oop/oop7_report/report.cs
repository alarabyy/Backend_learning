using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop7_delegate
{
    public class report
    {


        public void processless600(Employee[] employee)
        {
            Console.WriteLine("processless600:\n");
            Console.WriteLine("================");

            foreach (var x in employee)
            {
                if (x.salary <= 600)
                {
                    Console.WriteLine($"{x.Id} | {x.FirstName} | {x.LastName} | {x.Gender} | {x.salary}");
                }
                Console.WriteLine("===============================");
            }
        }


        public void process600(Employee[] employee) 
        {
            Console.WriteLine("process600:\n");
            Console.WriteLine("================");

            foreach (var x in employee)
            {
                if (x.salary >= 600)
                {
                    Console.WriteLine($"{x.Id} | {x.FirstName} | {x.LastName} | {x.Gender} | {x.salary}");
                }
            }
            Console.WriteLine("================================================");

        }


        public void process800(Employee[] employee)
        {
            Console.WriteLine("process800:\n");
            Console.WriteLine("================");

            foreach (var x in employee)
            {
                if (x.salary >= 800)
                {
                    Console.WriteLine($"{x.Id} | {x.FirstName} | {x.LastName} | {x.Gender} | {x.salary}");
                }
            }
            Console.WriteLine("================================================");

        }



        public void process900(Employee[] employee)
        {
            Console.WriteLine("process900:\n");
            Console.WriteLine("================");

            foreach (var x in employee)
            {
                if (x.salary >= 900)
                {
                    Console.WriteLine($"{x.Id} | {x.FirstName} | {x.LastName} | {x.Gender} | {x.salary}");
                }
            }
            Console.WriteLine("================================================");

        }

    }
}
