namespace oop20_genercs
{
     class Program
    {
        static void Main(string[] args)
        {
          
            //////////////////////////////////////////////////////////////////////////
            any<string> an = new any<string>("alaraby");
            any<int> an2 = new any<int>(10);
            any<double> an3 = new any<double>(10100.25);
            an.print();
            an2.print();
            an3.print();
            Console.WriteLine("=======================");
            //////////////////////////////////////////////////////////////////////////
            same<int,string> sa = new same<int, string>(1021,"alaraby");
            sa.print();
            Console.WriteLine("=======================");
            //////////////////////////////////////////////////////////////////////////
            mymethod<string>("alaraby3");
            Console.ReadKey();
        }

        public static void mymethod<type1>(type1 tt)
        {
            Console.WriteLine("val3:"+tt);
        }
       
        /////////////////////////////////////////////////////////////////////////////////////////
       

    }
    class any<mytype>
    {
        private mytype t;
        public any(mytype t)
        {
            this.t = t;
        }
        public void print()
        {
            Console.WriteLine("type:" + t.GetType().Name + " val:" + t);
        }

    }

    class same<type1, type2>
    {
        private type1 t;
        private type2 t2;
        public same(type1 t, type2 t2)
        {
            this.t = t;
            this.t2 = t2;
        }
        public void print()
        {
            Console.WriteLine("type:" + t.GetType().Name + " val:" + t);
            Console.WriteLine("type:" + t2.GetType().Name + " val:" + t2);
        }

    }
}
