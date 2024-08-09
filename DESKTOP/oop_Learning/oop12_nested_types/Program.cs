using System;

namespace oop12_nested_types
{
    public class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee();

            Console.WriteLine(employee.Ins.Policename ); 
            Console.WriteLine(employee.Ins.Policeid);
        }

        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Inssurance Ins { get; set; }

            public Employee()
            {
                Ins = new Inssurance{ Policeid = 12, Policename = "alarby" };
            }
        }

        public class Inssurance
        {
            public int Policeid { get; set; }
            public string Policename { get; set; }
        }

        class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
