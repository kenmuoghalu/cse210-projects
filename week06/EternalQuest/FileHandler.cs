using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class FileHandler
    {
        private string _filename = "goals.txt";

        public void SaveGoals(List<Goal> goals, int totalPoints)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filename))
                {
                    // Save total points first
                    writer.WriteLine(totalPoints);
                    
                    // Save each goal
                    foreach (Goal goal in goals)
                    {
                        writer.WriteLine(goal.GetSaveString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        public (List<Goal>, int) LoadGoals()
        {
            List<Goal> loadedGoals = new List<Goal>();
            int loadedPoints = 0;

            if (!File.Exists(_filename))
            {
                Console.WriteLine("No saved goals found.");
                return (loadedGoals, loadedPoints);
            }

            try
            {
                using (StreamReader reader = new StreamReader(_filename))
                {
                    // Read total points
                    if (int.TryParse(reader.ReadLine(), out int points))
                    {
                        loadedPoints = points;
                    }

                    // Read goals
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Goal goal = CreateGoalFromString(line);
                        if (goal != null)
                        {
                            loadedGoals.Add(goal);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }

            return (loadedGoals, loadedPoints);
        }

        private Goal CreateGoalFromString(string goalString)
        {
            string[] parts = goalString.Split('|');
            if (parts.Length < 5) return null;

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);

            switch (type)
            {
                case "SimpleGoal":
                    return new SimpleGoal(name, description, points, isComplete);
                
                case "EternalGoal":
                    int completionCount = parts.Length > 5 ? int.Parse(parts[5]) : 0;
                    return new EternalGoal(name, description, points, isComplete, completionCount);
                
                case "ChecklistGoal":
                    if (parts.Length >= 8)
                    {
                        int targetCount = int.Parse(parts[5]);
                        int currentCount = int.Parse(parts[6]);
                        int bonusPoints = int.Parse(parts[7]);
                        return new ChecklistGoal(name, description, points, isComplete, targetCount, currentCount, bonusPoints);
                    }
                    break;
            }

            return null;
        }
    }
}