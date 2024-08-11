using System;
using System.Collections.Generic;

namespace System_resturante
{
    public class FoodItem
    {
        // Read-only Name property
        public string Name { get; }

        // MealType property
        public MealType Type { get; set; }

        // Price property
        public decimal Price { get; set; }

        // Calories property, optional with a default value of 0
        public int Calories { get; set; } = 0;

        // Ingredients property, a list of ingredients
        public List<string> Ingredients { get; set; } = new List<string>();

        // Default constructor
        public FoodItem()
        {
        }

        // Constructor with name, type, and price
        public FoodItem(string name, MealType type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        // Constructor with name, type, price, and calories
        public FoodItem(string name, MealType type, decimal price, int calories)
        {
            Name = name;
            Type = type;
            Price = price;
            Calories = calories;
        }

        // Method to add an ingredient to the list
        public void AddIngredient(string ingredient)
        {
            Ingredients.Add(ingredient);
        }

        // Method to remove an ingredient from the list
        public void RemoveIngredient(string ingredient)
        {
            Ingredients.Remove(ingredient);
        }

        // Method to display food item details
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Calories: {Calories}");

            if (Ingredients.Count > 0)
            {
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in Ingredients)
                {
                    Console.WriteLine($"- {ingredient}");
                }
            }
            else
            {
                Console.WriteLine("Ingredients: None");
            }
        }
    }
}
public enum MealType
{
    Breakfast,
    Lunch,
    Dinner,
    Snack
}
