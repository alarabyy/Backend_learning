namespace oop10_operateroverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            money m1 =new money (200);
            money m2 =new money (200);

            money m3 = m1 + m2;
            money m4 = m1 - m2;
            money m5 = m1 * m2;
            money m6 = m1 / m2;

            Console.WriteLine($"amount1: {m1.Amount}");
            Console.WriteLine($"amount2: {m2.Amount}");
            Console.WriteLine($"amount3: {m3.Amount}");
            Console.WriteLine($"amount4: {m4.Amount}");
            Console.WriteLine($"amount5: {m5.Amount}");
            Console.WriteLine($"amount6: {m6.Amount}");
        }
    }
}
