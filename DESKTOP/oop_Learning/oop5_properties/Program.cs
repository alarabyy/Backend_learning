namespace oop5_properties
{
     class Program
    {
        static void Main(string[] args)
        {
            Dollar dollar = new Dollar(1000.5m);
            dollar.Amount = 1000.5m;
            Console.WriteLine(dollar.Amount);

        }
    }
}
