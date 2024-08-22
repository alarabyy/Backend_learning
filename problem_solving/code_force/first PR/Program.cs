using System;

class Program
{
    static void Main()
    {
        int w = int.Parse(Console.ReadLine());

        if (w > 2 && w % 2 == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}