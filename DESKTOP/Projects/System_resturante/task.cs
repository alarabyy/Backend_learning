// 1. Create an enum for the MealType (e.g., Breakfast, Lunch, Dinner, Snack)

// 2. Create the FoodItem Class:
//    - Constructors:
//      - Default constructor
//      - Constructor with name, type (MealType), and price
//      - Constructor with name, type, price, and calories

//    - Properties:
//      - Name (ReadOnly)
//      - Type (Based on the MealType Enum)
//      - Price
//      - Calories (Optional, default to 0 if not provided)
//      - Ingredients (List of strings, representing ingredients)

//    - Methods:
//      - AddIngredient(string ingredient) → Add an ingredient to the list
//      - RemoveIngredient(string ingredient) → Remove an ingredient from the list
//      - DisplayInfo() → Show food item details (name, type, price, calories, ingredients)

// 3. Create the Customer Class:
//    - Constructors:
//      - Default constructor
//      - Constructor with first & last name
//      - Constructor with first, last name, and phone number

//    - Properties:
//      - FullName (ReadOnly)
//      - PhoneNumber (Optional, can be updated later)
//      - Orders (List of FoodItems, representing customer orders)

//    - Methods:
//      - AddOrder(FoodItem foodItem) → Add a food item to the customer's order list
//      - RemoveOrder(FoodItem foodItem) → Remove a food item from the customer's order list
//      - CalculateTotalOrderValue() → Sum of all food items' prices in the order list
//      - DisplayOrderSummary() → Show summary of customer's orders including total value

// 4. Create the Waiter Class (Inherits from Customer):
//    - Properties:
//      - EmployeeID
//      - ManagedTables (List of int, representing table numbers managed by the waiter)

//    - Methods:
//      - TakeOrder(Customer customer, FoodItem foodItem) → Add an order to a customer
//      - ServeOrder(Customer customer) → Finalize and serve the customer's order
//      - DisplayInfo() → Show waiter's details (name, employee ID, managed tables)

// 5. Create the Restaurant Class:
//    - Properties:
//      - Name
//      - Address
//      - Menu (List of FoodItems)
//      - Customers (List of Customers)
//      - Waiters (List of Waiters)
//      - Tables (Dictionary<int, Customer>, where int is the table number)

//    - Methods:
//      - AddFoodItem(FoodItem foodItem) → Add a new food item to the menu
//      - RemoveFoodItem(FoodItem foodItem) → Remove a food item from the menu
//      - AssignTable(Customer customer, int tableNumber) → Assign a customer to a table
//      - GetWaiterByTable(int tableNumber) → Get the waiter assigned to a specific table
//      - DisplayMenu() → Show all food items available in the menu
//      - DisplayAllCustomers() → Show all customers and their orders
//      - DisplayAllWaiters() → Show all waiters and the tables they manage

// 6. Advanced Features (Optional):
//    - Handle exceptions such as assigning an occupied table or ordering a food item not on the menu.
//    - Implement discount functionality in the CalculateTotalOrderValue method based on specific conditions (e.g., bulk orders).
//    - Implement notifications for the waiter when a new customer is seated or when an order is ready to be served.
