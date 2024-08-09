namespace oop2_methods
{
     class Program
    {
        static void Main(string[] args)
        {

            Demo demo = new Demo();

            demo.step1();                     //caller
            //================================================================
            Console.WriteLine(demo.step2());  //caller
            //================================================================
            int age = 20;
            demo.step3(ref age);              //caller
            Console.WriteLine(age);
            //================================================================
            int num2;
            demo.step4(out age);
            Console.WriteLine(age);
            //================================================================
            var numage = "12135465";
            int numage2;
            if (! int.TryParse(numage, out numage2))
            {
                Console.WriteLine("invalide numbers");
            }
            else
            {
                Console.WriteLine($"number : {numage2}");

            }


            //================================================================
            Console.ReadKey();
            Console.WriteLine("======================================");
        }
    }

     public class Demo
    {
        public void step1()  //calle
        {
            Console.WriteLine("welcome\n");
        }

        public int step2()   //calle
        {
            int x = 10;
            return 20 * x;
        }

        public void step3(ref int age)
        {
             age = age + 3;
        }

        public void step4(out int age2)
        {
            age2 = 10;
            age2 = age2 + 3;
        }
    }
}
