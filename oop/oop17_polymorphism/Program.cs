namespace oop17_polymorphism
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Eagle e =new Eagle();
            e.Moving();
            graph gr = new graph();
            gr.run();
            Console.WriteLine(gr.GetType());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////subclass sc = new subclass(123);

            ////////////Console.WriteLine(sc);

            ////////////Console.ReadKey();

        }
    }
    abstract class monkey
    {
        public abstract void run();
      
    }
    class graph : monkey
    {
        public override void run()
        {
            Console.WriteLine("welcome");
        }
    }
    class Elephante : graph
    {
        public virtual void Moving()
        {
            Console.WriteLine("going to");
        }
    }
    class Eagle  : Elephante
    {
        public void Flying()
        {
            Console.WriteLine("flying");
        }
        public override void Moving()
        {
            base.Moving();
            Console.WriteLine("going ................");
        }
        
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    class baseclass
    {
        public int x;
        public baseclass(int value)
        {
            x = value;
        }
    }
    class subclass : baseclass
    {
        public subclass(int scvalue) : base(scvalue)
        {

        }
    }
}
