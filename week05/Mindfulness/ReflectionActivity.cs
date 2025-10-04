using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts;
    private List<string> _usedQuestions;

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        
        InitializePrompts();
        InitializeQuestions();
        _usedPrompts = new List<string>();
        _usedQuestions = new List<string>();
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.", 
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a significant challenge.",
            "Think of a time when you made a positive difference in someone's life.",
            "Think of a time when you demonstrated great patience."
        };
    }

    private void InitializeQuestions()
    {
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "What strengths did you discover in yourself during this experience?",
            "How has this experience shaped who you are today?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nReflect on the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience:");
        Console.Write("Starting in ");
        ShowCountdown(5);
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"\n\n{question} ");
            ShowSpinner(10);
            
            // Check if we've used all questions and reset if needed
            if (_usedQuestions.Count >= _questions.Count)
            {
                _usedQuestions.Clear();
            }
        }
        
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

    private string GetRandomQuestion()
    {
        // If all questions have been used, reset the used list
        if (_usedQuestions.Count >= _questions.Count)
        {
            _usedQuestions.Clear();
        }
        
        Random random = new Random();
        string selectedQuestion;
        
        do
        {
            selectedQuestion = _questions[random.Next(_questions.Count)];
        } 
        while (_usedQuestions.Contains(selectedQuestion));
        
        _usedQuestions.Add(selectedQuestion);
        return selectedQuestion;
    }
}