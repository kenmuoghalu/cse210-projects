using System;

using System;

class Program
{
    static void Main(string[] args)
    {
        // Generate random magic number between 1-100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = -1;
        int guessCount = 0;

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            
            // Add error handling for invalid input
            string input = Console.ReadLine();
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            guessCount++;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it in {guessCount} tries!");
            }
        }
    }
}