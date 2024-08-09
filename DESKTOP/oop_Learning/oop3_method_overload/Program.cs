namespace oop3_method_overload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            overload tr = new overload();
            tr.trip(100,"alexandar", "alexbus");
            Console.WriteLine("good luck !");
            //================================================================
            Console.Write("====================================================\n");
            Console.Write(tr.iseven(10));
            //================================================================
            Console.Write("====================================================\n");
           
            var array = new int[] { 1, 3, 3, 5, 2, 54, 354, 3, 10, 32, 323, 65 };
            localmethods.paramven(array);
        }
    }
}
