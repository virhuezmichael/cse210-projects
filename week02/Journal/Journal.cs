using System.Runtime.CompilerServices;
using System.IO;

public class Journal {
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry){
        _entries.Add(entry);
        
    }
    public void SaveFile(string fileName) {
        using (StreamWriter outputFile = new StreamWriter(fileName, append: true))
        {
            foreach (Entry entry in _entries){
                outputFile.WriteLine(entry.CompleteEntry());
            }    
        }
        Console.WriteLine("Entry saved!");
    }

    public void LoadFile(string fileName) {
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines) {
            string[] parts = line.Split(",");
            if (parts.Length >= 2)
            {
                Console.WriteLine (parts[0]);
                Console.WriteLine (parts[1]);
            } else {
                Console.WriteLine("problem reading file");
            }
        }
    }

    public void DisplayAllEntries() {
        foreach  (Entry entry in _entries) {
            Console.WriteLine($"Date: {entry._date} - Prompt: {entry._prompt}");
            Console.WriteLine($"Response: {entry._response}");
            Console.WriteLine();
        }
    }

    public void SearchByDate(string fileName, string date) {
    if (!File.Exists(fileName))
    {
        Console.WriteLine("The file does not exist.");
        return;
    }

    string[] lines = File.ReadAllLines(fileName);
    bool found = false;

    foreach (string line in lines)
    {
        if (line.StartsWith("Date:"))
        {
            // Ejemplo de línea: Date: 5/11/2025 - Prompt: ..., ...
            int startIndex = "Date: ".Length;
            int endIndex = line.IndexOf(" - Prompt:");

            if (endIndex > startIndex)
            {
                string lineDate = line.Substring(startIndex, endIndex - startIndex).Trim();

                if (lineDate == date)
                {
                    Console.WriteLine(line);
                    found = true;
                }
            }
        }
    }

    if (!found)
    {
        Console.WriteLine("No entries found for that date.");
    }
}


}