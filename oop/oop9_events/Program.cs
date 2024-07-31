using oop9_events;

namespace oop9_events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock("amazon");

            stock.Price = 100;
            stock.onpricechange += stock_onpricechange;

            stock.changestock(5005m);
            stock.changestock(0.02m);
            stock.changestock(0.00m);

        }

        private static void stock_onpricechange(Stock stock, decimal oldprice)
        {
            if(stock.Price > oldprice)
            {
                Console.ForegroundColor =ConsoleColor.Green;
                Console.WriteLine($"{stock.Name} : {stock.Price}");
            }else if (stock.Price < oldprice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{stock.Name} : {stock.Price}");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{stock.Name} : {stock.Price}");

            }
        }
    }
}

public delegate void stockchangehandle(Stock stock, decimal oldprice);
