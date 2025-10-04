using System;

class Program
{
    static void Main(string[] args)
    {
        // Display welcome message
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("This program is designed to help you practice mindfulness and reduce stress.");
        
        // Variables to track activity statistics
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;
        
        while (true)
        {
            // Display menu
            Console.WriteLine("\nPlease choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity"); 
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Show Activity Statistics");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice (1-5): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    breathingCount++;
                    break;
                    
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    reflectionCount++;
                    break;
                    
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    listingCount++;
                    break;
                    
                case "4":
                    Console.WriteLine("\n=== Activity Statistics ===");
                    Console.WriteLine($"Breathing Activities: {breathingCount}");
                    Console.WriteLine($"Reflection Activities: {reflectionCount}");
                    Console.WriteLine($"Listing Activities: {listingCount}");
                    Console.WriteLine($"Total Sessions: {breathingCount + reflectionCount + listingCount}");
                    Console.WriteLine("===========================");
                    break;
                    
                case "5":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Have a peaceful day!");
                    return;
                    
                default:
                    Console.WriteLine("Invalid choice. Please enter 1-5.");
                    break;
            }
        }
    }
}

/*
CREATIVITY AND EXCEEDING REQUIREMENTS:
1. Added activity statistics tracking that shows how many times each activity was performed
2. Added a menu option to display activity statistics
3. Implemented a more sophisticated breathing animation that simulates actual breathing patterns
4. Added input validation throughout the program
5. Enhanced the user interface with better formatting and visual separation
6. Added a comprehensive welcome message explaining the program's purpose
*/