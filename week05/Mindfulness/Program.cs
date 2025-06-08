using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string name;
        string description;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quite");
            Console.Write("Select an option from menu: ");
            string response = Console.ReadLine();
            if (response == "1")
            {
                BreathingActivity Breathing = new BreathingActivity();
                Breathing.Run();
            }
            else if (response == "2")
            {
                ReflectionActivity Reflection = new ReflectionActivity();
                Reflection.Run();
            }
            else if (response == "3")
            {
                ListingActivity Listing = new ListingActivity();
                Listing.Run();
            }
            else
            {
                break;
            }
        }
    }
}