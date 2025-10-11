using System;
using System.Collections.Generic;
using System.Linq;

namespace EternalQuest
{
    class Program
    {
        private static List<Goal> goals = new List<Goal>();
        private static int totalPoints = 0;
        private static FileHandler fileHandler = new FileHandler();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("Track your goals and earn points for eternal progression!\n");

            bool running = true;
            while (running)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        ShowScore();
                        break;
                    case "7":
                        // EXCEEDS REQUIREMENTS: Added level system and achievements
                        ShowLevelAndAchievements();
                        break;
                    case "8":
                        running = false;
                        Console.WriteLine("Keep progressing on your eternal quest!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("7. Show Level & Achievements"); // EXCEEDS REQUIREMENTS
            Console.WriteLine("8. Quit");
            Console.Write("Select an option: ");
        }

        static void CreateNewGoal()
        {
            Console.WriteLine("\n=== Create New Goal ===");
            Console.WriteLine("1. Simple Goal (one-time completion)");
            Console.WriteLine("2. Eternal Goal (repeating)");
            Console.WriteLine("3. Checklist Goal (multiple completions)");
            Console.Write("Select goal type: ");

            string typeChoice = Console.ReadLine();
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter point value: ");
            int points = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }

            Console.WriteLine("Goal created successfully!");
        }

        static void ListGoals()
        {
            Console.WriteLine("\n=== Your Goals ===");
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals yet. Create some goals to get started!");
                return;
            }

            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetProgress()}");
            }
        }

        static void RecordEvent()
        {
            ListGoals();
            if (goals.Count == 0) return;

            Console.Write("Enter the number of the goal to record: ");
            if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= goals.Count)
            {
                Goal selectedGoal = goals[goalNumber - 1];
                int pointsEarned = selectedGoal.RecordCompletion();
                
                if (pointsEarned > 0)
                {
                    totalPoints += pointsEarned;
                    Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
                    
                    // EXCEEDS REQUIREMENTS: Check for level up
                    CheckForLevelUp();
                }
                else
                {
                    Console.WriteLine("This goal is already completed or couldn't be recorded.");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        static void ShowScore()
        {
            Console.WriteLine($"\n=== Your Eternal Quest Progress ===");
            Console.WriteLine($"Total Points: {totalPoints}");
            Console.WriteLine($"Current Level: {CalculateLevel()}"); // EXCEEDS REQUIREMENTS
            Console.WriteLine($"Goals Completed: {goals.Count(g => g.IsComplete())}");
        }

        static void SaveGoals()
        {
            fileHandler.SaveGoals(goals, totalPoints);
            Console.WriteLine("Goals saved successfully!");
        }

        static void LoadGoals()
        {
            var result = fileHandler.LoadGoals();
            goals = result.Item1;
            totalPoints = result.Item2;
            Console.WriteLine("Goals loaded successfully!");
        }

        // EXCEEDS REQUIREMENTS: Added level system and achievements
        static int CalculateLevel()
        {
            return (totalPoints / 1000) + 1; // Level up every 1000 points
        }

        static void CheckForLevelUp()
        {
            int currentLevel = CalculateLevel();
            if (totalPoints >= (currentLevel * 1000))
            {
                Console.WriteLine($"🎉 LEVEL UP! You've reached Level {currentLevel + 1}! 🎉");
                
                // Award bonus points for leveling up
                int bonusPoints = currentLevel * 100;
                totalPoints += bonusPoints;
                Console.WriteLine($"You earned {bonusPoints} bonus points for leveling up!");
            }
        }

        static void ShowLevelAndAchievements()
        {
            Console.WriteLine("\n=== Level & Achievements ===");
            Console.WriteLine($"Current Level: {CalculateLevel()}");
            Console.WriteLine($"Points to Next Level: {CalculateLevel() * 1000 - totalPoints}");
            
            // Show achievements based on goal completion
            int simpleGoalsCompleted = goals.OfType<SimpleGoal>().Count(g => g.IsComplete());
            int eternalCompletions = goals.OfType<EternalGoal>().Sum(g => g.GetCompletionCount());
            int checklistGoalsCompleted = goals.OfType<ChecklistGoal>().Count(g => g.IsComplete());
            
            Console.WriteLine("\n🏆 Achievements:");
            if (simpleGoalsCompleted >= 1)
                Console.WriteLine($"✓ Beginner Goal Setter - Complete 1 simple goal");
            if (simpleGoalsCompleted >= 5)
                Console.WriteLine($"✓ Goal Master - Complete 5 simple goals");
            if (eternalCompletions >= 10)
                Console.WriteLine($"✓ Eternal Warrior - 10 eternal goal completions");
            if (checklistGoalsCompleted >= 3)
                Console.WriteLine($"✓ Checklist Champion - Complete 3 checklist goals");
            if (totalPoints >= 5000)
                Console.WriteLine($"✓ Point Collector - Reach 5000 total points");
        }
    }
}