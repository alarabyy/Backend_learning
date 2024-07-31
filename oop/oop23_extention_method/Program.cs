namespace oop23_extention_method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);
            dt = new DateTime(2020, 4,2,2,00,00);
            Console.WriteLine(dt);

            DateTimeOffset dts = DateTimeOffset.Now;     ///now and  (+ or -)  utc 
            Console.WriteLine(dts);
            DateTimeOffset dts2 = DateTimeOffset.UtcNow; //UTC NOW
            Console.WriteLine(dts2);
            Console.WriteLine("good,luck !");

            /////go to  extention to  find all inforamation
        }
    }
}
