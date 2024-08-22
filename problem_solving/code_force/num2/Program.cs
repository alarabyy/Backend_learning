using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int petya = int.Parse(inputs[0]);
            int vasya = int.Parse(inputs[1]);
            int tonya = int.Parse(inputs[2]);

            if (petya + vasya + tonya >= 2)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}
