namespace oop11_finalizer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            testfinalizer();
            Console.WriteLine($"memory before collection {GC.GetTotalMemory(false):N}");
            Console.WriteLine($"memory before collection {GC.GetTotalMemory(false):}");
            Console.WriteLine($"memory before collection {GC.GetTotalMemory(false):N00}");
            GC.Collect();
            Console.WriteLine($"memory after collection {GC.GetTotalMemory(true):N0}");
            Console.ReadLine();

        }
        static void testfinalizer()
        {
            Version v;
            for (int i = 0; i < 1000; i++)
            {
                v = new Version();
            }
        }
    }
}
