namespace oop16_inhertance
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            Lions lion = new Lions();
            ///////////////////Lions ani = a as Lions;
            ///////////////////Lions lions2 = (Lions)a;
            Eagle a = lion;
            Elephante e =(Elephante)a;
            e.Moving();
           

        }   
    }
    sealed class Animals   //dont inheritance
    {
        public void Moving()
        {
            Console.WriteLine("going to");
        }
    }
    abstract class Elephante 
    {
        public void Moving2()
        {
            Console.WriteLine("going to");
        }
    }
     class Eagle : Elephante
    {
        public  void Flying() 
        {
            Console.WriteLine("flying");
        }
    }
     class Lions : Eagle
    {
        public  void Eating()
        {
            Console.WriteLine("eaying");
        }
    }

}
