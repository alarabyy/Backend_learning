namespace oop19_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Honda h = new Honda("elentra","sport",2020);
            Caterpiller c =new Caterpiller("boldozer","big",2010);
            Boldozer b = new Caterpiller("boldozer", "big", 2010);
            Idrivable m = new Caterpiller("boldozer", "big", 2010);
            b.loader();
            b.unloader();
            m.stop();
            m.move();

            
            
        }
    }
    ///////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////class_number1
    abstract class vehicle
    {
        protected string barnd;
        protected string model;
        protected int year;
        public vehicle(string barnd, string model, int year)
        {
            this.barnd = barnd;
            this.model = model;
            this.year = year;
        }
    }


    ///////////////////////////interface boldozer
    interface Boldozer
    {
        void loader();
        void unloader();
    }    
    ///////////////////////////interface idrivadel
    interface Idrivable
    {
        void move();
        void stop();
    }
    ///////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////class_number2
    class Honda : vehicle ,Idrivable 
    {
        public Honda(string barnd, string model, int year) : base(barnd, model, year)
        {

        }

        public void move()
        {
            Console.WriteLine("move");
        }

        public void stop()
        {
            Console.WriteLine("stop");
        }
    }    
    ///////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////class_number3
    class Caterpiller : vehicle , Boldozer , Idrivable
    {
        public Caterpiller(string barnd, string model, int year) : base(barnd, model, year)
        {

        }

        public void loader()
        {
            Console.WriteLine("loader");
        }

        public void move()
        {
            Console.WriteLine("move");
        }

        public void stop()
        {
            Console.WriteLine("stop");
        }

        public void unloader()
        {
            Console.WriteLine("unloader");
        }
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        class Bikes : vehicle , Moveingg, rides
        {
            public Bikes(string barnd, string model, int year) : base (barnd, model, year)
            {

            }

            void Moveingg.move()
            {
                Console.WriteLine("moving");
            }

            void rides.move()
            {
                Console.WriteLine("moving2");
            }
        }
        interface Moveingg
        {
            void move();
        }
        interface rides
        {
            void move();
        }
    }
}
