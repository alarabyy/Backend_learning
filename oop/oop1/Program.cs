namespace oop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee emp1 = new Employee();   //read class
            
            //read vars
            Console.Write("Enter fname:");
            emp1.Fname = Console.ReadLine();

            Console.Write("Enter Lname:");
            emp1.Lname = Console.ReadLine();

            Console.Write("Enter Basesalary:");
            emp1.Basesalary =Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Houresalary:");
            emp1.Houresalary = Convert.ToDouble(Console.ReadLine());

            //calc salary
            var allsalary = ((emp1.Basesalary + emp1.Houresalary) - Employee.Tax);
            //print vars
            Console.WriteLine($"fname= {emp1.Fname}");
            Console.WriteLine($"lname= {emp1.Lname}");
            Console.WriteLine($"salary= {allsalary}");



            Console.WriteLine("=====================================================" );


            Employee emp2 = new Employee();   //read class

            //read vars
            Console.Write("Enter fname:");
            emp2.Fname = Console.ReadLine();

            Console.Write("Enter Lname:");
            emp2.Lname = Console.ReadLine();

            Console.Write("Enter Basesalary:");
            emp2.Basesalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Houresalary:");
            emp2.Houresalary = Convert.ToDouble(Console.ReadLine());

            //calc salary
            var allsalary2 = ((emp2.Basesalary + emp2.Houresalary) - Employee.Tax);
            //print vars
            Console.WriteLine($"fname= {emp2.Fname}");
            Console.WriteLine($"lname= {emp2.Lname}");
            Console.WriteLine($"salary= {allsalary2}");



            Console.WriteLine("=====================================================");
            Console.WriteLine("=====================================================");
            Console.WriteLine("=====================================================");


            Employee[] emps = new Employee[1];   //read class to array
            Employee emp3 = new Employee();   //read class


            //read vars
            Console.Write("Enter fname:");
            emp3.Fname = Console.ReadLine();

            Console.Write("Enter Lname:");
            emp3.Lname = Console.ReadLine();

            Console.Write("Enter Basesalary:");
            emp3.Basesalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Houresalary:");
            emp3.Houresalary = Convert.ToDouble(Console.ReadLine());


            emps[0] = emp3;

            foreach (var em in emps)
            {
                //calc salary
                var allsalary3 = ((em.Basesalary + em.Houresalary) - Employee.Tax);
                //print vars
                Console.WriteLine($"fname= {em.Fname}");
                Console.WriteLine($"lname= {em.Lname}");
                Console.WriteLine($"salary= {allsalary3}");
            }

        }
    }
}
