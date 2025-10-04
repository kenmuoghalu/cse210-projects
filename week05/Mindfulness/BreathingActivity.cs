using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("\nStarting breathing exercise...");
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            // Breathe in
            Console.Write("\nBreathe in... ");
            ShowBreathingAnimation(4, true);
            
            if (DateTime.Now >= endTime) break;
            
            // Breathe out  
            Console.Write("\nBreathe out... ");
            ShowBreathingAnimation(6, false);
        }
        
        DisplayEndingMessage();
    }

    // Enhanced breathing animation that simulates actual breathing patterns
    private void ShowBreathingAnimation(int seconds, bool breathingIn)
    {
        string[] animation;
        
        if (breathingIn)
        {
            // Gradual expansion for breathing in
            animation = new string[] { "[•       ]", "[••      ]", "[•••     ]", "[••••    ]", 
                                     "[•••••   ]", "[••••••  ]", "[••••••• ]", "[••••••••]" };
        }
        else
        {
            // Gradual contraction for breathing out
            animation = new string[] { "[••••••••]", "[••••••• ]", "[••••••  ]", "[•••••   ]", 
                                     "[••••    ]", "[•••     ]", "[••      ]", "[•       ]" };
        }
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int frameDuration = seconds * 1000 / animation.Length;
        int frameIndex = 0;
        
        while (DateTime.Now < endTime && frameIndex < animation.Length)
        {
            Console.Write(animation[frameIndex]);
            Thread.Sleep(frameDuration);
            
            // Clear the animation frame
            for (int i = 0; i < animation[frameIndex].Length; i++)
            {
                Console.Write("\b \b");
            }
            
            frameIndex++;
        }
    }
}