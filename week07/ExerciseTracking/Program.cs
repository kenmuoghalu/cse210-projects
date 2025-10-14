using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create activities of each type
        List<Activity> activities = new List<Activity>();
        
        // Running activity
        activities.Add(new Running(new DateTime(2023, 11, 3), 30, 3.0));
        
        // Cycling activity  
        activities.Add(new Cycling(new DateTime(2023, 11, 3), 30, 15.0));
        
        // Swimming activity
        activities.Add(new Swimming(new DateTime(2023, 11, 3), 30, 20));

        // Display summaries for all activities
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("=========================");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}