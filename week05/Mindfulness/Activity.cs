using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Activity";
        _description = "A mindfulness activity";
        _duration = 0;
    }

    // Common starting message for all activities
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}!");
        Console.WriteLine($"\n{_description}");
        
        // Get duration from user
        while (true)
        {
            Console.Write("\nHow long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number.");
            }
        }
        
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    // Common ending message for all activities
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\n\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Show a spinning animation
    protected void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        
        string[] spinner = { "|", "/", "-", "\\" };
        int spinnerIndex = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[spinnerIndex]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            
            spinnerIndex = (spinnerIndex + 1) % spinner.Length;
        }
    }

    // Show a countdown timer
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Virtual method that can be overridden by derived classes
    public virtual void Run()
    {
        DisplayStartingMessage();
        DisplayEndingMessage();
    }
}