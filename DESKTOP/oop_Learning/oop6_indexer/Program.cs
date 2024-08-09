using oop6_indexer;

namespace oop_6_indexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
          ip i =new ip(192,172,0,110);

            var index = i;
           Console.WriteLine(i.Adrees);
            Console.WriteLine(index[0]);
            Console.WriteLine(index[1]);
            Console.WriteLine(index[2]);
            Console.WriteLine(index[3]);
        }
    }
}
