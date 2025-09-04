using System;

class Program
{
    static void Main(string[] args)
    {
        // Display welcome message
        DisplayWelcome();
        
        // Get user input
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        
        // Process the number
        int squaredNumber = SquareNumber(userNumber);
        
        // Display final result
        DisplayResult(userName, squaredNumber);
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
    
    static void DisplayWelcome()
    {
        Console.WriteLine("====================================");
        Console.WriteLine("Welcome to the Program!");
        Console.WriteLine("====================================\n");
    }
    
    static string PromptUserName()
    {
        string name;
        do
        {
            Console.Write("Please enter your name: ");
            name = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty. Please try again.\n");
            }
            
        } while (string.IsNullOrEmpty(name));
        
        return name;
    }
    
    static int PromptUserNumber()
    {
        int number;
        bool isValid;
        
        do
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();
            
            isValid = int.TryParse(input, out number);
            
            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.\n");
            }
            
        } while (!isValid);
        
        return number;
    }
    
    static int SquareNumber(int number)
    {
        // Using Math.Pow and converting back to int for a different approach
        return (int)Math.Pow(number, 2);
    }
    
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine($"RESULT: {userName}, the square of your number is {squaredNumber}");
        Console.WriteLine(new string('=', 50));
    }
}