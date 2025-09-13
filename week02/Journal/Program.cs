using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;
        
        Console.WriteLine("Welcome to the Journal Program!");
        
        while (running)
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();
            
            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.\n");
                    break;
            }
        }
    }
}

/*
Creativity and Exceeding Requirements:

1. Added mood tracking: Each journal entry includes a mood field that is either suggested randomly
   or can be customized by the user. This helps users track their emotional state alongside their entries.

2. Implemented proper CSV handling: The program correctly handles commas and quotation marks in 
   journal entries when saving and loading CSV files. It uses proper CSV formatting with quotes
   around fields that contain commas or quotes, and escapes quotes within fields.

3. Added journal statistics: When displaying the journal, the program shows statistics including:
   - Total number of entries
   - Average words per entry
   - Average characters per entry
   - Mood distribution across all entries

4. Expanded prompt list: Added more prompts beyond the required five to provide greater variety.

5. Enhanced user experience: Added suggested mood with the option to change it, providing guidance
   while still allowing user customization.

*/