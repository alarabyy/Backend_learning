using System;
using System.Collections.Generic;
using System_resturante;

namespace RestaurantSystem
{
    public class Restaurant
    {
        // Properties
        public string Name { get; set; }
        public string Address { get; set; }
        public List<FoodItem> Menu { get; set; } = new List<FoodItem>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Waiter> Waiters { get; set; } = new List<Waiter>();
        public Dictionary<int, Customer> Tables { get; set; } = new Dictionary<int, Customer>();

        // Constructor
        public Restaurant(string name, string address)
        {
            Name = name;
            Address = address;
        }

        // Methods
        public void AddFoodItem(FoodItem foodItem)
        {
            Menu.Add(foodItem);
        }

        public void RemoveFoodItem(FoodItem foodItem)
        {
            Menu.Remove(foodItem);
        }

        public virtual void AssignTable(Customer customer, int tableNumber)
        {
            if (Tables.ContainsKey(tableNumber))
            {
                Console.WriteLine($"Table {tableNumber} is already occupied.");
            }
            else
            {
                Tables[tableNumber] = customer;
                Customers.Add(customer);
                Console.WriteLine($"Customer {customer.FullName} has been assigned to table {tableNumber}.");
            }
        }

        public Waiter GetWaiterByTable(int tableNumber)
        {
            foreach (var waiter in Waiters)
            {
                if (waiter.ManagedTables.Contains(tableNumber))
                {
                    return waiter;
                }
            }
            return null; // No waiter found for this table
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            foreach (var foodItem in Menu)
            {
                foodItem.DisplayInfo();
                Console.WriteLine();
            }
        }

        public void DisplayAllCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in Customers)
            {
                customer.DisplayOrderSummary();
                Console.WriteLine();
            }
        }

        public void DisplayAllWaiters()
        {
            Console.WriteLine("Waiters:");
            foreach (var waiter in Waiters)
            {
                waiter.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}
