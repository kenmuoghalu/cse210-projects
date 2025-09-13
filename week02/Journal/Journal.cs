using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private List<string> _moods; // Additional feature to exceed requirements

    public Journal()
    {
        _entries = new List<Entry>();
        
        // Initialize prompts
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What lesson did I learn today?"
        };
        
        // Initialize moods for additional feature
        _moods = new List<string>
        {
            "Happy", "Grateful", "Peaceful", "Excited", "Content",
            "Tired", "Anxious", "Frustrated", "Sad", "Reflective"
        };
    }

    public void WriteNewEntry()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        string mood = _moods[random.Next(_moods.Count)]; // Random mood suggestion
        
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine($"Suggested mood: {mood} (feel free to change)");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        Console.Write("Mood (press enter to use suggested): ");
        string userMood = Console.ReadLine();
        if (!string.IsNullOrEmpty(userMood))
        {
            mood = userMood;
        }
        
        string date = DateTime.Now.ToString("MM/dd/yyyy");
        
        Entry newEntry = new Entry(date, prompt, response, mood);
        _entries.Add(newEntry);
        
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }
        
        Console.WriteLine("Journal Entries:\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        
        // Additional feature: Show statistics
        ShowStatistics();
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Write header for CSV
                writer.WriteLine("Date,Prompt,Response,Mood");
                
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ExportToCsv());
                }
            }
            
            Console.WriteLine($"Journal saved to {filename} successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}\n");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist.\n");
            return;
        }
        
        try
        {
            List<Entry> loadedEntries = new List<Entry>();
            
            using (StreamReader reader = new StreamReader(filename))
            {
                // Skip header
                reader.ReadLine();
                
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Parse CSV line
                    string[] parts = ParseCsvLine(line);
                    
                    if (parts.Length >= 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];
                        string mood = parts.Length > 3 ? parts[3] : "";
                        
                        loadedEntries.Add(new Entry(date, prompt, response, mood));
                    }
                }
            }
            
            _entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {filename} successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}\n");
        }
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> parts = new List<string>();
        bool inQuotes = false;
        int start = 0;
        
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (line[i] == ',' && !inQuotes)
            {
                string part = line.Substring(start, i - start);
                if (part.StartsWith("\"") && part.EndsWith("\""))
                {
                    part = part.Substring(1, part.Length - 2).Replace("\"\"", "\"");
                }
                parts.Add(part);
                start = i + 1;
            }
        }
        
        // Add the last part
        string lastPart = line.Substring(start);
        if (lastPart.StartsWith("\"") && lastPart.EndsWith("\""))
        {
            lastPart = lastPart.Substring(1, lastPart.Length - 2).Replace("\"\"", "\"");
        }
        parts.Add(lastPart);
        
        return parts.ToArray();
    }

    private void ShowStatistics()
    {
        Console.WriteLine("=== Journal Statistics ===");
        Console.WriteLine($"Total entries: {_entries.Count}");
        
        if (_entries.Count > 0)
        {
            // Calculate average response length
            int totalWords = 0;
            int totalCharacters = 0;
            Dictionary<string, int> moodCounts = new Dictionary<string, int>();
            
            foreach (Entry entry in _entries)
            {
                totalWords += entry._response.Split(new char[] {' ', '\t', '\n'}, 
                                  StringSplitOptions.RemoveEmptyEntries).Length;
                totalCharacters += entry._response.Length;
                
                if (!string.IsNullOrEmpty(entry._mood))
                {
                    if (moodCounts.ContainsKey(entry._mood))
                    {
                        moodCounts[entry._mood]++;
                    }
                    else
                    {
                        moodCounts[entry._mood] = 1;
                    }
                }
            }
            
            Console.WriteLine($"Average words per entry: {totalWords / _entries.Count}");
            Console.WriteLine($"Average characters per entry: {totalCharacters / _entries.Count}");
            
            if (moodCounts.Count > 0)
            {
                Console.WriteLine("\nMood distribution:");
                foreach (var mood in moodCounts)
                {
                    Console.WriteLine($"{mood.Key}: {mood.Value} entries");
                }
            }
        }
        
        Console.WriteLine("=========================\n");
    }
}