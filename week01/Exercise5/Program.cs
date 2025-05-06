using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        string name;
        int number;
        int square;

        static void DisplayWelcome() {
            Console.WriteLine("Welcome to the Program");
        }
        string PromtUserName() {
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            return name;
        }
        void PromptUserNumber() {
            Console.Write("Please enter your favorite number: ");
            number = int.Parse(Console.ReadLine());
        }
        void SquareNumber(int number) {
            square = number * number;
        }
        static void DisplayResult(int square, string name) {
            Console.WriteLine($"{name}, the square of your number is: {square}");
        }

        DisplayWelcome();
        PromtUserName();
        PromptUserNumber();
        SquareNumber(number);
        DisplayResult(square, name);
    }
}