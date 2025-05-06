using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do{
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1,100);

            string response;
            int guess;
            int guesses = 0;


            do {
                Console.Write("What is your guess? ");
                response = Console.ReadLine();
                guess = int.Parse(response);
                guesses++;

                if (guess > number) {
                    Console.WriteLine("Lower");
                } else if (guess < number) {
                    Console.WriteLine("Higher");
                } else {
                    Console.Write("You guessed it! ");
                }
            } while (guess != number);

            Console.WriteLine($"It took you {guesses} guesses.");
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");
        
        Console.WriteLine("Thanks for playing!");
    }
}