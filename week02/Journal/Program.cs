using System;

class Program
{
    static void Main(string[] args)
    {
        string optionSelected;

        PromptMaker prompt = new PromptMaker();
        Journal journal = new Journal();

        do {
            Console.WriteLine("Please selec one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            optionSelected = Console.ReadLine();

            if (optionSelected != "1" && optionSelected != "2" && optionSelected != "3" && optionSelected != "4" && optionSelected != "5" ) {
                Console.WriteLine("Invalid option. Please select a valid option.");
            } else {
                if (optionSelected == "1") {
                    Entry entry = new Entry();
                    entry._prompt = prompt.GetPrompt();
                    Console.WriteLine(entry._prompt);
                    entry._response = Console.ReadLine();
                    DateTime currentTime = DateTime.Now;
                    entry._date = currentTime.ToShortDateString();
                    journal.AddEntry(entry);
                } else if (optionSelected == "2") {
                    journal.DisplayAllEntries();
                } else if (optionSelected == "3") {
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();
                    journal.LoadFile(filename);
                } else if (optionSelected == "4") {
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();
                    journal.SaveFile(filename);
                } else {
                    Console.WriteLine("Have a nice day!");
                }
            }

        } while (optionSelected != "5");
    }
}