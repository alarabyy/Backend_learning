using System.Collections.Generic;
namespace Collections
{
    public class Program
    {
        static void Main(string[] args)
        {
            //an object
            var egypt = new country { ISOcode = "eg", Name = "egypt" };
            var iraq = new country { ISOcode = "irq", Name = "iraq" };
            var gaban = new country { ISOcode = "gab", Name = "gaban" };
           
        // array
        country[] arrcuntry =
        {
            egypt,
            iraq,
            gaban
        };


        //create list//==================================================================================

            //constructor
            List<country> countries = new List<country>();
            //property

            //method
            countries.Add(new country { ISOcode = "eg", Name = "egypt" }); //an oject  0(1)
            countries.AddRange(arrcuntry);  //add array
            countries.Insert(2, new country { ISOcode = "gab", Name = "gaban" } );   //0(n)
            countries.Insert(3, new country { ISOcode = "usa", Name = "usa" } );     //0(n)
            countries.Remove(new country { ISOcode = "usa", Name = "usa" });     //0(n)

            foreach (var item in countries)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }

    }
    public class country
    {
        public string ISOcode { get; set; }
        public string  Name { get; set; }

        public override string ToString()
        {
            return $"{ISOcode}>>{Name}";

        }
    }
}
