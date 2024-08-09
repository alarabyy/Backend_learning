namespace _25_attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            update[] updates =
            {
            new update  ( 1 ,"hamo"),
            new update  ( 2 ,"ahmed"),
            new update  ( 3 ,"ali"),
            new update  ( 4 ,"mahmod")
            };


            Console.WriteLine("-------------------!");
            //updateprossecor.download(updates);
            //updateprossecor.insatall(updates);
           updateprossecor.downloadandinsatall (updates);
            Console.WriteLine("-------------------!");
            Console.ReadKey();
        }
    }

    class updateprossecor
    {
        ///////////////////////////////////////////////////////////////////////////////
        [Obsolete("this is not support!!!" , false)]
        public static void download(update[] updates)
        {
            for (int i = 0; i < updates.Length; i++)
            {
                Console.WriteLine("download:" + updates[i]);
                System.Threading.Thread.Sleep(2000);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////
        [Obsolete("this is not support!!!" , false)]
        public static void insatall(update[] updates)
        {
            for (int i = 0; i < updates.Length; i++)
            {
                Console.WriteLine("insatall:" + updates[i]);
                System.Threading.Thread.Sleep(2000);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////
        public static void downloadandinsatall(update[] updates)
        {
            for (int i = 0; i < updates.Length; i++)
            {
                Console.WriteLine("insatall:" + updates[i]);
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("|--------------------------|");
                Console.WriteLine("download:" + updates[i]);
                System.Threading.Thread.Sleep(2000);
                 

            }
        }
    }
    class update
    {
        private int number;
        private string title;



        public update(int number, string title)
        {
            this.number = number;
            this.title = title;
        }

        public override string ToString()
        {
            return $"\n number: {number}\n title:{title}";
        }
    } 
}

