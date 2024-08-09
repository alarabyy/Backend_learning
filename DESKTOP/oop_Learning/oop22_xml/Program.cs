namespace oop22_xml
{
    public class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("first name :");
                var fname = Console.ReadLine();

                Console.WriteLine("last name :");
                var lname = Console.ReadLine();

                Console.WriteLine("date :");
                DateTime? hiredate = null;
                if (DateTime.TryParse(Console.ReadLine(), out DateTime hdate)) ;

                var empid = Generator.ganrateid(fname, lname, hiredate);
                var randpass = Generator.ganraterandonpass(10);

                Console.WriteLine($"empid:{empid} \n fname:{fname} \n lastname:{lname} \n pass:{randpass}");
            } while (1 == 1);
        } 
    }
}
