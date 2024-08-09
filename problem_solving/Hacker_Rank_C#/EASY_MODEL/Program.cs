//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            Console.WriteLine("Hello: Alexandra Abramov");

//        }
//    }
//}
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//using System;

//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            // Prompt user for the first number and read input
//            Console.Write("Input the first number: ");
//            string input1 = Console.ReadLine();
//            double number1 = Convert.ToDouble(input1);

//            // Prompt user for the second number and read input
//            Console.Write("Input the second number: ");
//            string input2 = Console.ReadLine();
//            double number2 = Convert.ToDouble(input2);

//            // Check if the second number is not zero to avoid division by zero
//            if (number2 != 0)
//            {
//                // Calculate and display the result of division
//                double result = number1 / number2;
//                Console.WriteLine("Result: " + result);
//            }
//            else
//            {
//                // Display error message if attempting to divide by zero
//                Console.WriteLine("Error: Cannot divide by zero.");
//            }
//        }
//        catch (FormatException)
//        {
//            // Catch block for handling non-numeric input errors
//            Console.WriteLine("Error: Non-numeric value entered.");
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An error occurred: " + ex.Message);
//        }
//    }
//}

//----------------------------------------------------------------------
//----------------------------------------------------------------------
//using System;
//using System.Net;

//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            // Prompt user to input an integer and read the input
//            Console.Write("Input an integer: ");
//            int number = Convert.ToInt32(Console.ReadLine());

//            // Call the method to validate if the input is a positive number
//            ValidatePositiveNumber(number);

//            // Display the input as valid if it passes validation
//            Console.WriteLine("Valid input: " + number);
//        }
//        catch (NegativeNumberException ex)
//        {
//            // Catch block for handling NegativeNumberException
//            Console.WriteLine("Error: " + ex.Message);
//        }
//        catch (FormatException)
//        {
//            // Catch block for handling FormatException (non-integer input)
//            Console.WriteLine("Error: Invalid input. Please enter an integer.");
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An error occurred: " + ex.Message);
//        }
//    }

//    // Method to validate if the number is positive
//    static void ValidatePositiveNumber(int number)
//    {
//        if (number < 0)
//        {
//            // Throw NegativeNumberException if the number is negative
//            throw new NegativeNumberException("Negative number not allowed.");
//        }
//    }
//}

//// Custom exception class for handling negative number scenarios
//class NegativeNumberException : Exception
//{
//    public NegativeNumberException(string message) : base(message) { }
//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;
//using System.IO;

//class Program
//{
//    static void Main()
//    {
//        // Prompt user to input the file path and read the input
//        Console.Write("Input the file path: ");
//        string filePath = Console.ReadLine();

//        try
//        {
//            // Attempt to open the file using StreamReader within a using block for automatic resource disposal
//            using (StreamReader reader = new StreamReader(filePath))
//            {
//                // File opened successfully
//                Console.WriteLine("File opened successfully.");
//            }
//        }
//        catch (FileNotFoundException)
//        {
//            // Catch block for handling FileNotFoundException
//            Console.WriteLine("Error: File not found.");
//        }
//        catch (IOException ex)
//        {
//            // Catch block for handling IOException while accessing the file
//            Console.WriteLine("An error occurred while accessing the file: " + ex.Message);
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An unexpected error occurred: " + ex.Message);
//        }
//    }
//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;

//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            // Prompt the user to input a number
//            Console.Write("Input a number: ");
//            string input = Console.ReadLine();

//            // Attempt to convert the user input to an integer
//            int number = ConvertToInt(input);

//            // Display the converted number
//            Console.WriteLine("Number: " + number);
//        }
//        catch (FormatException)
//        {
//            // Catch block for handling FormatException when non-integer input is entered
//            Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An error occurred: " + ex.Message);
//        }
//    }

//    // Method to convert string input to an integer
//    static int ConvertToInt(string input)
//    {
//        return int.Parse(input); // Convert string to integer
//    }
//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        // Create a list to store integers
//        List<int> numbers = new List<int>();

//        try
//        {
//            // Prompt the user to input a list of integers, enter 'exit' to finish
//            Console.WriteLine("Input a list of integers (Input 'exit' to finish):");

//            // Continuously read user input until 'exit' is entered
//            while (true)
//            {
//                Console.Write("Input an integer: ");
//                string input = Console.ReadLine();

//                // Check if user wants to exit the loop
//                if (input.ToLower() == "exit")
//                    break;

//                // Convert user input to an integer and add it to the list
//                int number = ConvertToInt32(input);
//                numbers.Add(number);
//            }

//            // Display the numbers entered by the user
//            Console.WriteLine("Numbers entered:");
//            foreach (int number in numbers)
//            {
//                Console.WriteLine(number);
//            }
//        }
//        catch (FormatException)
//        {
//            // Catch block for handling FormatException when non-integer input is entered
//            Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
//        }
//        catch (OverflowException)
//        {
//            // Catch block for handling OverflowException when the entered value is outside the range of Int32
//            Console.WriteLine("Error: The value entered is outside the range of Int32.");
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An error occurred: " + ex.Message);
//        }
//    }

//    // Method to convert string input to an integer
//    static int ConvertToInt32(string input)
//    {
//        return int.Parse(input); // Convert string to Int32
//    }
//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;

//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            // Prompt the user to input the numerator and convert it to an integer
//            Console.Write("Input the numerator: ");
//            int numerator = Convert.ToInt32(Console.ReadLine());

//            // Prompt the user to input the denominator and convert it to an integer
//            Console.Write("Input the denominator: ");
//            int denominator = Convert.ToInt32(Console.ReadLine());

//            // Call the DivideNumbers method to perform division and store the result
//            int result = DivideNumbers(numerator, denominator);

//            // Display the division result to the user
//            Console.WriteLine("Result: " + result);
//        }
//        catch (DivideByZeroException)
//        {
//            // Catch block for handling DivideByZeroException (division by zero error)
//            Console.WriteLine("Error: Division by zero is not allowed.");
//        }
//        catch (FormatException)
//        {
//            // Catch block for handling FormatException (invalid input format)
//            Console.WriteLine("Error: Invalid input. Please enter valid integers.");
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An error occurred: " + ex.Message);
//        }
//    }

//    // Method to perform division of two integers
//    static int DivideNumbers(int numerator, int denominator)
//    {
//        return numerator / denominator; // Perform integer division
//    }
//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;

//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            // Ask the user to input a number
//            Console.Write("Input a number: ");
//            double number = Convert.ToDouble(Console.ReadLine());

//            // Check if the input number is non-negative
//            if (number >= 0)
//            {
//                // Calculate the square root if the number is non-negative
//                double squareRoot = CalculateSquareRoot(number);
//                Console.WriteLine("Square root: " + squareRoot);
//            }
//            else
//            {
//                // Throw an ArgumentException if the number is negative
//                throw new ArgumentException("Number cannot be negative!");
//            }
//        }
//        catch (FormatException)
//        {
//            // Catch block for handling FormatException (invalid input)
//            Console.WriteLine("Error: Invalid input. Please input a valid number.");
//        }
//        catch (ArgumentException ex)
//        {
//            // Catch block for handling ArgumentException (negative number)
//            Console.WriteLine("Error: " + ex.Message);
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An error occurred: " + ex.Message);
//        }
//    }

//    // Method to calculate the square root of a number
//    static double CalculateSquareRoot(double number)
//    {
//        // Using the Math.Sqrt method to calculate the square root
//        return Math.Sqrt(number);
//    }
//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;

//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            // Ask the user to input a positive number
//            Console.Write("Input a positive number (integer): ");
//            int number = Convert.ToInt32(Console.ReadLine());

//            // Calculate factorial of the entered number
//            int factorial = CalculateFactorial(number);

//            // Display the calculated factorial
//            Console.WriteLine("Factorial: " + factorial);
//        }
//        catch (OverflowException)
//        {
//            // Catch block for handling OverflowException (if the factorial exceeds Int32.MaxValue)
//            Console.WriteLine("Error: Factorial exceeds the maximum value of Int32.");
//        }
//        catch (FormatException)
//        {
//            // Catch block for handling FormatException (invalid input format)
//            Console.WriteLine("Error: Invalid input. Please enter a valid number.");
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An error occurred: " + ex.Message);
//        }
//    }

//    // Method to calculate the factorial of a number
//    static int CalculateFactorial(int number)
//    {
//        // Check if the input number is negative
//        if (number < 0)
//        {
//            // Throw an ArgumentException for negative input numbers
//            throw new ArgumentException("Number must be non-negative.");
//        }

//        // Initialize the factorial as 1
//        int factorial = 1;

//        // Loop to calculate the factorial
//        for (int i = 1; i <= number; i++)
//        {
//            checked
//            {
//                // Multiply the current value of factorial with the loop variable (i)
//                factorial *= i; // The checked keyword checks for overflow and throws an OverflowException if detected
//            }
//        }

//        // Return the calculated factorial value
//        return factorial;
//    }
//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;
//using System.Net;

//class Program
//{
//    static void Main()
//    {
//        // Prompt the user to input URLs, one URL per line, and press Enter to complete
//        Console.WriteLine("Input the URLs (one URL per line, press Enter to complete):");

//        try
//        {
//            while (true)
//            {
//                // Read the URL entered by the user
//                string url = Console.ReadLine();

//                // Check if the entered URL is null, empty, or contains only whitespace
//                if (string.IsNullOrWhiteSpace(url))
//                {
//                    // Break out of the loop if the entered URL is empty or whitespace
//                    break;
//                }

//                // Call the method to download content from the specified URL
//                DownloadContent(url);
//            }
//        }
//        catch (WebException ex)
//        {
//            // Catch block for handling WebException when accessing URLs
//            Console.WriteLine("Error accessing URL: " + ex.Message);
//        }
//        catch (Exception ex)
//        {
//            // Catch block for handling other types of exceptions
//            Console.WriteLine("An error occurred: " + ex.Message);
//        }
//    }

//    // Method to download content from a specified URL and display it
//    static void DownloadContent(string url)
//    {
//        // Create a new instance of WebClient to download content
//        WebClient webClient = new WebClient();

//        // Download the content from the provided URL
//        string content = webClient.DownloadString(url);

//        // Display the content of the downloaded URL
//        Console.WriteLine("Content of URL '" + url + "':");
//        Console.WriteLine(content);
//        Console.WriteLine();
//    }
//}

//----------------------------------------------------------------------
//----------------------------------------------------------------------
//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            int num_1 = 10;
//            int num_2 = 20;

//            Console.WriteLine(num_1+num_2);
//            Console.ReadKey();
//        }
//    }
//}
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            int num_1 = 10;
//            int num_2 = 20;

//            Console.WriteLine(num_1 + num_2);
//            Console.ReadKey();
//        }
//    }
//}
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            int num_1 = 10;
//            int num_2 = 20;

//            Console.WriteLine(num_2 / num_1);
//            Console.ReadKey();
//        }
//    }
//}
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {




//            Console.WriteLine(-1 + 4 * 6 +"\n");
//            Console.WriteLine((35 + 5) % 7 + "\n");
//            Console.WriteLine(14 + -4 * 6 / 11 + "\n");
//            Console.WriteLine(2 + 15 / 6 * 1 - 7 % 2 + "\n");

//            Console.ReadKey();
//        }
//    }
//}
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            int num_1 ,num_2 ,swap;

//            Console.WriteLine("enter num 1");
//            num_1 = int.Parse(Console.ReadLine());

//            Console.WriteLine("enter num 2");
//            num_2 = int.Parse(Console.ReadLine());

//            swap = num_1;
//            num_1 = num_2;
//            num_2 = swap;

//            Console.WriteLine("num 1="+num_1);
//            Console.WriteLine("num 2="+num_2);

//            Console.ReadKey();
//        }
//    }
//}
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            int num_1, num_2, swap;

//            Console.WriteLine("enter num 1");
//            num_1 = int.Parse(Console.ReadLine());

//            Console.WriteLine("enter num 2");
//            num_2 = int.Parse(Console.ReadLine());

//            swap = num_1;
//            num_1 = num_2;
//            num_2 = swap;

//            Console.WriteLine("num 1=" + num_1);
//            Console.WriteLine("num 2=" + num_2);

//            Console.ReadKey();
//        }
//    }
//}
////----------------------------------------------------------------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {



//            //////node one = new node(1);
//            //////node two = new node(2);
//            //////node three = new node(3);

//            //////Console.WriteLine(one.Data);
//            //////one.Next =two;

//            //////Console.WriteLine(one.Next);
//            ///
//            //List 1 = new List()

//            Console.ReadKey();
//        }



//    }
//}
////----------------------------------------------------------------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {


//            Console.WriteLine("enter num1");
//            int num_1 = int.Parse(Console.ReadLine()); 
//            Console.WriteLine("enter num2");
//            int num_2 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num3");
//            int num_3 = int.Parse(Console.ReadLine());

//            int resuly = (num_1 * num_2 * num_3);
//            Console.WriteLine("result=" + resuly);
//            Console.ReadKey();
//        }



//    }
//}
//----------------------------------------------------------------------
//---------------------------(calc__(add,sup,multi,divi)---------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {


//            Console.WriteLine("enter num1");
//            int num_1 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num2");
//            int num_2 = int.Parse(Console.ReadLine());


//            int resuly_1 = (num_1 + num_2);
//            int resuly_2 = (num_1 - num_2);
//            int resuly_3 = (num_1 * num_2);
//            int resuly_4 = (num_1 / num_2);
//            Console.WriteLine("result_1=" + resuly_1+"\n");
//            Console.WriteLine("result_1=" + resuly_2+"\n");
//            Console.WriteLine("result_1=" + resuly_3+"\n");
//            Console.WriteLine("result_1=" + resuly_4+"\n");
//            Console.ReadKey();
//        }
//    }
//}
//----------------------------------------------------------------------
//------------------------------(calc__table_num* loop)-----------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            start:
//            Console.WriteLine("enter num:");
//            int num =int.Parse(Console.ReadLine());
//            for (int i = 1; i <11 ; i++)
//            {
//            Console.WriteLine(i + "x" + num + "=" + i * num + "\n");

//            }

//            goto start;
//            Console.ReadKey();
//        }
//    }
//}
////----------------------------------------------------------------------
////------------------------------(calc__table_num* loop)-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//        start:
//            Console.WriteLine("enter num_1:");
//            int num_1 = int.Parse(Console.ReadLine());

//            Console.WriteLine("enter num_2:");
//            int num_2 = int.Parse(Console.ReadLine());

//            Console.WriteLine("enter num_3:");
//            int num_3 = int.Parse(Console.ReadLine());

//            Console.WriteLine("enter num_4:");
//            int num_4 = int.Parse(Console.ReadLine());


//            int result = (num_1 + num_2 + num_3 + num_4) / 4;
//            Console.WriteLine("avrage:"+result);
//            goto start;
//            Console.ReadKey();
//        }
//    }
//}
////----------------------------------------------------------------------
////------------------------------(calc__table_num* loop)-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//        start:

//            Console.WriteLine("enter num_1:");
//            int num_1 = int.Parse(Console.ReadLine());

//            Console.WriteLine("enter num_2:");
//            int num_2 = int.Parse(Console.ReadLine());

//            Console.WriteLine("enter num_3:");
//            int num_3 = int.Parse(Console.ReadLine());



//            if (num_1 + num_2 + num_3 != 0)
//            {
//                int result_1 = ((num_1 + num_2) / num_3);
//                int result_2 = ((num_1 * num_2) + (num_3 / num_2));
//                int result_3 = ((num_1 * num_2) + (num_3 * num_2));

//                Console.WriteLine("result_1=" + result_1);
//                Console.WriteLine("result_2=" + result_2);
//                Console.WriteLine("result_3=" + result_3);
//            }
//            else
//            {
//                Console.WriteLine("num == 0 enter num again");
//                goto start;

//            }
//            Console.ReadKey();
//        }
//    }
//}
////----------------------------------------------------------------------
////------------------------------()-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {


//            Console.WriteLine("enter age:");
//            int age = int.Parse(Console.ReadLine());

//            Console.WriteLine("You look older than :) \t"+ age);
//            Console.ReadKey();
//        }
//    }
//}
//----------------------------------------------------------------------
//------------------------------()-----------------
//----------------------------------------------------------------------
//----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {


//            Console.WriteLine("enter num_1:");
//            int num_1 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num_2:");
//            int num_2 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num_3:");
//            int num_3 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num_4:");
//            int num_4 = int.Parse(Console.ReadLine());


//            Console.WriteLine("line_1 :"+ num_1 + "\t" + num_2 + "\t" + num_3 + "\t" + num_4 +"\n"+
//                              "line_2 :" + num_1 + num_2  + num_3  + num_4 +"\n"+
//                              "line_1 :" + num_1 + "\t" + num_2 + "\t" + num_3 + "\t" + num_4 + "\n" +
//                              "line_2 :" + num_1 + num_2 + num_3 + num_4 + "\n"
//                              );

//            Console.ReadKey();
//        }
//    }
//}
////----------------------------------------------------------------------
////------------------------------()-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {


//            Console.WriteLine("enter num_1:");
//            int num_1 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num_2:");
//            int num_2 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num_3:");
//            int num_3 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num_4:");
//            int num_4 = int.Parse(Console.ReadLine());


//            Console.WriteLine("line_1 :" + num_1 + "\t" + num_2 + "\t" + num_3 + "\t" + num_4 + "\n" +
//                              "line_2 :" + num_1 + num_2 + num_3 + num_4 + "\n" +
//                              "line_1 :" + num_1 + "\t" + num_2 + "\t" + num_3 + "\t" + num_4 + "\n" +
//                              "line_2 :" + num_1 + num_2 + num_3 + num_4 + "\n"
//                              );

//            Console.ReadKey();
//        }
//    }
//}
////----------------------------------------------------------------------
////------------------------------()-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {


//            Console.WriteLine("enter num_1:");
//            int num_1 = int.Parse(Console.ReadLine());



//            Console.WriteLine(num_1+""+num_1+""+num_1+"\n"+
//                              num_1 + " " + num_1 +"\n"+
//                              num_1 + "" + num_1 + "" + num_1 + "\n"+
//                              num_1 + " " + num_1 +"\n"
//                              );

//            Console.ReadKey();
//        }
//    }
//}
////----------------------------------------------------------------------
////------------------------------()-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------

//using System;
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            string name_1;
//            string name_2;
//            string CONV_1="";
//            string CONV_2 = "";
//            Console.WriteLine("enter name_1 :");
//            name_1 = (Console.ReadLine());
//            Console.WriteLine("enter name_2 :");
//            name_2 = (Console.ReadLine());

//            for (int i= name_1.Length - 1;  i >= 0 ; i--)
//            {
//                CONV_1 += name_1[i];
//            }
//            for (int i = name_2.Length - 1; i >= 0; i--)
//            {
//                CONV_2 += name_2[i];
//            }
//            Console.WriteLine(CONV_1);
//            Console.WriteLine(CONV_2);

//            Console.ReadKey();
//        }


//    }
//}
//////----------------------------------------------------------------------
//////------------------------------()-----------------
//////----------------------------------------------------------------------
//////----------------------------------------------------------------------

////using System;
////using System.Collections.Generic;

////namespace problem_solving
////{
////    internal class Program
////    {
////        static void Main(string[] args)
////        {
////            string name_1;
////            Console.WriteLine("enter name_1 :");
////            name_1 = Console.ReadLine();

////            if (name_1.Length >=1) 
////            {
////                var s =name_1.Substring(0,1);
////                Console.WriteLine(s+name_1+s);

////            }

////            Console.ReadKey();
////        }


////    }
////}
////----------------------------------------------------------------------
////------------------------------()-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------

//using System;
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int num1;
//            int num2;

//            Console.WriteLine("enter num1 :");
//            num1 =int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num1 :");
//            num2 = int.Parse(Console.ReadLine());

//            Console.WriteLine("check one is negative and one is positive");

//            if (num1 !=0 && num2 !=0) 
//            {
//                Console.WriteLine("true");
//            }
//            Console.ReadKey();
//        }
//    }
//}

////----------------------------------------------------------------------
////------------------------------()-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------

//using System;
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int num1;
//            int num2;

//            Console.WriteLine("enter num1 :");
//            num1 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num1 :");
//            num2 = int.Parse(Console.ReadLine());



//            Console.WriteLine(Sumamer(num1, num2));
//            Console.ReadKey();
//    }

//        public static int Sumamer(int num1, int num2)
//        {


//                return num1 == num2 ? num1*1000*10000 : num1+num2;

//        }
//    }
//}
////----------------------------------------------------------------------
////------------------------------()-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------

//using System;
//using System.Collections;
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            start:
//            int num1;
//            int num2;

//            Console.WriteLine("enter num1 :");
//            num1 = int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num1 :");
//            num2 = int.Parse(Console.ReadLine());


//            Console.WriteLine(absoliot(num1, num2));

//            goto start;

//            Console.ReadKey();
//        }

//        public static int absoliot(int x, int t)
//        {
//            if (x > t)
//            {
//                return (x - t) * 2;
//            }
//            return x - t;
//        }

//    }
//}

////----------------------------------------------------------------------
////------------------------------()-----------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------

//using System;
//using System.Collections;
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        private static object console;

//        static void Main(string[] args)
//        {
//        start:
//            int x;
//            int y;

//            Console.WriteLine("enter num1 :");
//            x= int.Parse(Console.ReadLine());
//            Console.WriteLine("enter num1 :");
//            y =int.Parse(Console.ReadLine());


//            Console.WriteLine(x == 20 || y == 20 || x + y == 20);

//            goto start;

//            Console.ReadKey();
//        }
//    }
//}
////----------------------------------------------------------------------
//22.Write a C# program to check if the given integer is within 20 of 100 or 200.
//Sample Output:
//Input an integer:
//25
//False
////----------------------------------------------------------------------

//using System;
//using System.Collections.Generic;

//// This is the beginning of the Exercise22 class
//public class Exercise22
//{
//    // This is the main method where the program execution starts
//    static void Main(string[] args)
//    {
//        Console.WriteLine("\nInput an integer:"); // Prompting the user to input an integer
//        int x = Convert.ToInt32(Console.ReadLine()); // Reading the integer input provided by the user

//        Console.WriteLine(result(x)); // Calling the 'result' method and printing the result
//    }

//    // Method to check if the given integer is within 20 units of 100 or 200
//    public static bool result(int n)
//    {
//        if (Math.Abs(n - 100) <= 20 || Math.Abs(n - 200) <= 20)
//            return true; // Return true if the condition is satisfied
//        return false; // Return false if the condition is not satisfied
//    }
//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//23.Write a C# program to convert a given string into lowercase.
//Sample Output:
//write a c# sharp program to display the following pattern using the alphabet
////----------------------------------------------------------------------
////----------------------------------------------------------------------

//using System;
//using System.Collections;
//using System.Collections.Generic;

//namespace problem_solving
//{
//    internal class Program
//    {
//        private static object console;

//        static void Main(string[] args)
//        {


//            string words = "hello and welcome every bodt";
//            Console.WriteLine(words.ToLower());
//            Console.WriteLine(words.ToUpper());
//            Console.ReadKey();
//        }
//    }
//}


////----------------------------------------------------------------------
////----------------------------------------------------------------------
//24.Write a C# program to find the longest word in a string.
//Test Data: Write a C# Sharp Program to display the following pattern using the alphabet.
////----------------------------------------------------------------------
////----------------------------------------------------------------------

//using System;  
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//// This is the beginning of the Exercise24 class
//public class Exercise24
//{
//    // This is the main method where the program execution starts
//    public static void Main()
//    {
//        string line = "Write a C# Sharp Program to display the following pattern using the alphabet.";

//        // Splitting the string into words based on spaces and storing them in an array
//        string[] words = line.Split(new[] { " " }, StringSplitOptions.None);

//        string word = ""; // Initializing an empty string to store the word with the maximum length
//        int ctr = 0; // Initializing a counter variable to keep track of the maximum length

//        // Looping through each word in the words array
//        foreach (String s in words)
//        {
//            // Checking if the length of the current word is greater than the stored maximum length
//            if (s.Length > ctr)
//            {
//                word = s; // If the current word's length is greater, update the 'word' variable
//                ctr = s.Length; // Update the maximum length counter
//            }
//        }

//        Console.WriteLine(word); // Displaying the word with the maximum length
//    }
//}


////----------------------------------------------------------------------
////----------------------------------------------------------------------
//25.Write a C# program to print odd numbers from 1 to 99. Prints one number per line.
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;

//public class num
//{
//    public static void Main()
//    {
//        int num;
//        Console.WriteLine("enter num:");
//        num = int.Parse(Console.ReadLine());

//        for (int i = 0; i < num; i++)
//        {

//            if (i % 2 != 0)
//            {
//                Console.WriteLine("num ("+i+")="+i);
//            }

//        }
//    }

//}

////----------------------------------------------------------------------
////----------------------------------------------------------------------
//26.Write a C# program to compute the sum of the first 500 prime numbers.
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//using System;

//public class Exercise10
//{
//    public static void Main()
//    {
//        // Declare variables to store two numbers and a boolean to determine if both are even
//        int n1, n2;
//        bool bothEven;

//        // Input the first number
//        Console.Write("Input First number: ");
//        n1 = Convert.ToInt32(Console.ReadLine());

//        // Input the second number
//        Console.Write("Input Second number: ");
//        n2 = Convert.ToInt32(Console.ReadLine());

//        // Check if both numbers are even using logical operators
//        bothEven = ((n1 % 2 == 0) && (n2 % 2 == 0)) ? true : false;

//        // Output the result based on whether both numbers are even or not
//        Console.WriteLine(bothEven ? "There're numbers both even" : "There's a number odd");
//    }
//}

////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////------------------------------------------------------------------------------------------------------------------------------
////----------------------------------------------------------------------
////----------------------------------------------------------------------
///1. Write a program in C# Sharp to display the first 10 natural numbers.
////----------------------------------------------------------------------
//using System;
//class forloop
//{
//    public static void Main()
//    {
//        for(int i = 1; i <= 10; i++)
//        {
//            System.Console.WriteLine(i);
//        }
//    }
//}
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//2.Write a C# Sharp program to find the sum of the first 10 natural numbers.
////----------------------------------------------------------------------
//using System;
//class forloop
//{
//    public static void Main()
//    {
//        int num = 0;
//        for (int i = 1; i <= 10; i++)
//        {
//            num += i;
//            System.Console.WriteLine(i+"="+num);

//        }

//    }
//}
////----------------------------------------------------------------------
////----------------------------------------------------------------------
//3.Write a C# Sharp program that displays the sum of n natural numbers.
////----------------------------------------------------------------------
//using System;
//class forloop
//{
//    public static void Main()
//    {
//        int num = 0;
//        for (int i = 1; i <= 5; i++)
//        {
//            Console.WriteLine(i);
//            num += i;
//        }
//        Console.WriteLine("sum num 5 =" + num);

//    }
//}
////----------------------------------------------------------------------
////----------------------------------------------------------------------
///4. Write a C# Sharp program to read average and sum.
////----------------------------------------------------------------------
//using System;
//class forloop
//{
//    public static void Main()
//    {

//        Console.WriteLine("enter two  number ");
//        int num_1 =int.Parse(Console.ReadLine());
//        int num_2 =int.Parse(Console.ReadLine());
//        int result = (num_1 / num_2 );

//        Console.WriteLine("avrege nums =" + result);

//    }
//}
////----------------------------------------------------------------------
////----------------------------------------------------------------------
///5. Write a C# Sharp program to display the cube of an integer up to given number.
////----------------------------------------------------------------------
// using System;
// class forloop
// {
//     public static void Main()
//     {

//         Console.WriteLine("enter number ");
//         int num_1 = int.Parse(Console.ReadLine());

//         for (int i = 1; i <= num_1; i++)
//         {
//         Console.WriteLine("avrege num "+ i + "=" + i * i * i );
//         }


//     }
// }
////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------

////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------
////----------------------------------------------------------------------
///
////----------------------------------------------------------------------

////----------------------------------------------------------------------