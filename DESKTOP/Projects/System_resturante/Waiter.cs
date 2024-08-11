using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_resturante
{
        // Waiter class that inherits from Customer
        public class Waiter : Customer
        {
            public int EmployeeID { get; set; }
            public List<int> ManagedTables { get; set; } = new List<int>();

            public Waiter(int employeeID, string firstName, string lastName)
                : base(firstName, lastName)
            {
                EmployeeID = employeeID;
            }

            public void TakeOrder(Customer customer, FoodItem foodItem)
            {
                customer.AddOrder(foodItem);
            }

            public void ServeOrder(Customer customer)
            {
                Console.WriteLine($"Serving order for {customer.FullName}");
                customer.DisplayOrderSummary();
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Waiter: {FullName}");
                Console.WriteLine($"Employee ID: {EmployeeID}");
                Console.WriteLine("Managed Tables:");
                foreach (var table in ManagedTables)
                {
                    Console.WriteLine($"- Table {table}");
                }
            }
        }
    }
