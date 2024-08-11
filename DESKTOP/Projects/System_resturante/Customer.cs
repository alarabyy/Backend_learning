using System;
using System.Collections.Generic;
using System.Linq;

namespace System_resturante
{
    public class Customer
    {
        // Read-only FullName property
        public string FullName => $"{FirstName} {LastName}";

        // First name property
        public string FirstName { get; set; }

        // Last name property
        public string LastName { get; set; }

        // PhoneNumber property, optional and can be updated later
        public string PhoneNumber { get; set; }

        // Orders property, a list of FoodItems representing customer orders
        public List<FoodItem> Orders { get; set; } = new List<FoodItem>();

        // Default constructor
        public Customer()
        {
        }

        // Constructor with first & last name
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // Constructor with first, last name, and phone number
        public Customer(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        // Method to add a food item to the customer's order list
        public void AddOrder(FoodItem foodItem)
        {
            Orders.Add(foodItem);
        }

        // Method to remove a food item from the customer's order list
        public void RemoveOrder(FoodItem foodItem)
        {
            Orders.Remove(foodItem);
        }

        // Method to calculate the total value of all food items in the order list
        public decimal CalculateTotalOrderValue()
        {
            return Orders.Sum(order => order.Price);
        }

        // Method to display a summary of the customer's orders, including total value
        public void DisplayOrderSummary()
        {
            Console.WriteLine($"Customer: {FullName}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine("Order Summary:");

            foreach (var order in Orders)
            {
                Console.WriteLine($"- {order.Name}: {order.Price:C}");
            }

            Console.WriteLine($"Total Order Value: {CalculateTotalOrderValue():C}");
        }
    }
}
