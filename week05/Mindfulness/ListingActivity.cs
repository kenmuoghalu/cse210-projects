using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;
    private int _itemCount;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        
        InitializePrompts();
        _usedPrompts = new List<string>();
        _itemCount = 0;
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are you grateful for today?",
            "What positive experiences have you had recently?",
            "What accomplishments are you proud of?",
            "What makes you feel happy and content?",
            "Who has shown you kindness lately?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nList as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---");
        
        Console.Write("\nGet ready to start listing... ");
        ShowCountdown(5);
        
        Console.WriteLine("\n\nStart listing now!");
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        _itemCount = 0;
        
        // Collect items until time runs out
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(item))
            {
                _itemCount++;
            }
            
            // Show a small spinner to indicate time is passing
            if (DateTime.Now < endTime)
            {
                Console.Write("Time remaining... ");
                ShowSpinner(2);
            }
        }
        
        Console.WriteLine($"\nYou listed {_itemCount} items!");
        
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        // If all prompts have been used, reset the used list
        if (_usedPrompts.Count >= _prompts.Count)
        {
            _usedPrompts.Clear();
        }
        
        Random random = new Random();
        string selectedPrompt;
        
        do
        {
            selectedPrompt = _prompts[random.Next(_prompts.Count)];
        } 
        while (_usedPrompts.Contains(selectedPrompt));
        
        _usedPrompts.Add(selectedPrompt);
        return selectedPrompt;
    }
}