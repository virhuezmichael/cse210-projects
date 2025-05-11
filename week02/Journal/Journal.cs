using System.Runtime.CompilerServices;
using System.IO;

public class Journal {
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry){
        _entries.Add(entry);
        
    }
    public void SaveFile(string fileName) {
        using (StreamWriter outputFile = new StreamWriter(fileName))
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

}