using System;
using System.Runtime.Versioning;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        double grade = Convert.ToDouble(input);
        string letter;
        string sign = "";
        if (grade >= 90) {
            letter = "A";
        } else if (grade >= 80) {
            letter = "B";;
        } else if (grade >= 70) {
            letter = "C";;
        } else if (grade >= 60) {
            letter = "D";;
        } else {
            letter = "F";;
        }

        int lastDigit = (int)grade % 10;

        if (letter != "A" && letter != "F") {
            if (lastDigit >= 7) {
                sign = "+";
            } else if (lastDigit < 3) {
                sign = "-";
            }
        } else if (letter == "A" && lastDigit <3) {
            sign = "-";
        }

        Console.WriteLine($"Your letter grade is {letter}{sign}");

        if (grade < 70) {
            Console.WriteLine("Unfortunately you did not pass the course. You will do the next time!");
        } else {
            Console.WriteLine("Congratulations! You passed the course");
        }
    }
}