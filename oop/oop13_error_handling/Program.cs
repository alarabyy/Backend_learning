namespace oop13_error_handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("enter num1");
            int num1 =int.Parse(Console.ReadLine());
            Console.WriteLine("enter num2");
            int num2 = int.Parse(Console.ReadLine());

            money(num1,num2);
            Console.WriteLine("============================");
            goto start;
        }


        public static void money(int member ,int month)
        {
            try
            {
                Console.WriteLine((member / month));
            } 
            catch (Exception e) 
            {
                Console.WriteLine($"eror handling {e.Message}");
            }
            finally 
            {
                Console.WriteLine($"please try again");
            }
        }


    }
}
