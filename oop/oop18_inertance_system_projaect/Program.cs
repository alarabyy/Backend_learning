using oop18_inertance_system_projaect;

namespace oop18_inertance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manger m = new Manger()
            {
                Id = 4,
                Name = "Manger",
                Wave = 4000m,
                Loggedhour = 8m,
            };
          ///////////////  Console.WriteLine(m);
            Console.WriteLine("============================");
            Maintains ms = new Maintains()
            {
                Id = 1,
                Name = "alaraby",
                Wave = 5000m,
                Loggedhour = 8m,
            };
           /////////// Console.WriteLine(ms);
            Console.WriteLine("============================");
            sales s = new sales()
            {
                Id = 1,
                Name = "sales",
                Wave = 10000m,
                Loggedhour = 24m,
                taskcompleted = true,
            };
            /////////// Console.WriteLine(s);
            Console.WriteLine("============================");
            Developer d = new Developer()
            {
                Id = 100,
                Name = "Developer",
                Wave = 10000m,
                Loggedhour = 10m,
            };
           ////// Console.WriteLine(s);
            Console.WriteLine("============================");
            Employee[] em = { m , d , ms , s ,};
            foreach (var item in em)
            {
                Console.WriteLine("\n-------------\n");
                Console.WriteLine(item);
            }
        }
    }


    ///////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////
 


}
