using System;
using System.Linq.Expressions;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference();
        string scriptureText = "For behold, I, God, have suffered these things for all, that they might not suffer if they would repent";
        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();

            Console.WriteLine($"{reference.GetReference()}: {scripture.GetDisplayText()}");
            Console.WriteLine();
            Console.WriteLine("Press enter to continue, type 'hint' for hint or type 'quit' to finish:");
            string response = Console.ReadLine();

            if (response.ToLower() == "quit" || scripture.isCompletelyHidden())
                break;
            
            if (response.ToLower() == "hint")
            {
                scripture.ShowHint();
                continue;
            }
                
            scripture.HideRandomWords(3);
        }
        
    }
}