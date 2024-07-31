namespace oop21_exeption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                person p = new person("ahmed");
                p.printname();
            }catch (my_exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
