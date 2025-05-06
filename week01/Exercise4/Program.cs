using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int response;
        int sum = 0;
        double average;
        int largestNumber;
        int smallestNumber = 1000000;


        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do {
            Console.Write("Enter number: ");
            response = int.Parse(Console.ReadLine());
            if (response != 0) {
                numbers.Add(response);
            }
        } while (response != 0);

        if (numbers.Count > 0)
        {
            largestNumber = numbers[0];
            foreach (int number in numbers) {
                sum += number;
                if (number > largestNumber) {
                    largestNumber = number;
                }
                 if (number > 0) {
                    if (number < smallestNumber){
                        smallestNumber = number;
                    }
                }     
            }

            average = (double)sum / numbers.Count;

            Console.WriteLine("The sum is: " + sum);
            Console.WriteLine("The average is: " + average);
            Console.WriteLine("The largest number is: " + largestNumber);
            if (smallestNumber == 1000000) {
                Console.WriteLine("There is no smallest number.");
            } else {
                Console.WriteLine("The smallest number is: " + smallestNumber);
            }
            numbers.Sort();
            foreach (int num in numbers){
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}