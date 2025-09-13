using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood; // Additional field to exceed requirements

    public Entry(string date, string prompt, string response, string mood = "")
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        if (!string.IsNullOrEmpty(_mood))
        {
            Console.WriteLine($"Mood: {_mood}");
        }
        Console.WriteLine();
    }

    public string ExportToCsv()
    {
        // Properly handle CSV formatting by escaping quotes and commas
        string escapedResponse = _response.Replace("\"", "\"\"");
        string escapedPrompt = _prompt.Replace("\"", "\"\"");
        
        if (escapedResponse.Contains(",") || escapedResponse.Contains("\"") || 
            escapedPrompt.Contains(",") || escapedPrompt.Contains("\""))
        {
            return $"\"{_date}\",\"{escapedPrompt}\",\"{escapedResponse}\",\"{_mood}\"";
        }
        else
        {
            return $"{_date},{escapedPrompt},{escapedResponse},{_mood}";
        }
    }
}