using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter numbers to calculate statistics (enter 0 to finish):");
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            
            // Error handling for invalid input
            if (!int.TryParse(userResponse, out userNumber))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }
            
            // Only add the number to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Check if any numbers were entered (excluding 0)
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Part 1: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Part 2: Compute the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average:F2}"); // Format to 2 decimal places

        // Part 3: Find the max
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");

        // Bonus: Find the min
        int min = numbers[0];
        foreach (int number in numbers)
        {
            if (number < min)
            {
                min = number;
            }
        }
        
        Console.WriteLine($"The min is: {min}");
        
        // Bonus: Sort and display the list
        numbers.Sort();
        Console.WriteLine($"Sorted numbers: {string.Join(", ", numbers)}");
    }
}