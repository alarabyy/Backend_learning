using System;
namespace oop15_enum
{
     class Program
    {
        static void Main(string[] args)
        {

             Console.WriteLine(Month.twelve.ToString());
             Console.WriteLine((int)Month.twelve) ;
             Console.WriteLine(Month.twelve);
            Console.WriteLine("=======================") ;
            
            var day = (Days.friday | Days.saturday);
            if (day.HasFlag(Days.weekend))
            {
                Console.WriteLine("engooooy !!");
            }
            Console.WriteLine("=======================");
            
            foreach (var item in Enum.GetNames(typeof(Month))) 
            {
                Console.WriteLine($"{item} = {(int)Enum.Parse(typeof(Month),item)}");
            }
            
        }
    }
    //simple enum
    /// ///enum Month : int
    enum Month 
    {
        one =1,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        eleven,
        twelve

    }
    //flags
    enum Days
    {
        none      = 0b_0000_0000,//0
        saturday  = 0b_0000_0001,//1
        sunday    = 0b_0000_0010,//2
        monday    = 0b_0000_0100,//4
        tuesday   = 0b_0000_1000,//8
        wednesday = 0b_0001_0000,//16
        thursday  = 0b_0010_0000,//32
        friday    = 0b_0100_0000,//64
        weekend   = saturday | friday, //0b_0100_0001  
        businesday = sunday | monday | tuesday | wednesday | thursday, //
    }
}
