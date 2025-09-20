using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements: 
        // 1. Added a library of scriptures that loads from a file (scriptures.txt)
        // 2. Randomly selects a scripture from the library each time the program runs
        // 3. Added difficulty levels that control how many words are hidden at once
        
        ScriptureLibrary library = new ScriptureLibrary();
        library.LoadScripturesFromFile("scriptures.txt");
        
        Scripture scripture = library.GetRandomScripture();
        
        if (scripture == null)
        {
            Console.WriteLine("No scriptures found in the library.");
            return;
        }
        
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("Choose difficulty level:");
        Console.WriteLine("1. Easy (2 words hidden at a time)");
        Console.WriteLine("2. Medium (3 words hidden at a time)");
        Console.WriteLine("3. Hard (5 words hidden at a time)");
        Console.Write("Enter your choice (1-3): ");
        
        int difficulty;
        while (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3)
        {
            Console.Write("Please enter a valid number (1-3): ");
        }
        
        int wordsToHide = difficulty == 1 ? 2 : (difficulty == 2 ? 3 : 5);
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Good job memorizing!");
                break;
            }
            
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                break;
            }
            
            scripture.HideRandomWords(wordsToHide);
        }
    }
}

// Exceeding requirements: Added a ScriptureLibrary class to manage multiple scriptures
public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;
    
    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
    }
    
    public void LoadScripturesFromFile(string filename)
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    string reference = parts[0];
                    string text = parts[1];
                    string[] refParts = reference.Split(' ');
                    
                    string book = refParts[0];
                    string chapterVerse = refParts[1];
                    
                    string[] cvParts = chapterVerse.Split(':');
                    int chapter = int.Parse(cvParts[0]);
                    
                    string[] verseParts = cvParts[1].Split('-');
                    int startVerse = int.Parse(verseParts[0]);
                    
                    if (verseParts.Length > 1)
                    {
                        int endVerse = int.Parse(verseParts[1]);
                        Reference refObj = new Reference(book, chapter, startVerse, endVerse);
                        _scriptures.Add(new Scripture(refObj, text));
                    }
                    else
                    {
                        Reference refObj = new Reference(book, chapter, startVerse);
                        _scriptures.Add(new Scripture(refObj, text));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures: {ex.Message}");
        }
    }
    
    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            return null;
        }
        
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
