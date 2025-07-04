using System;
using System.Collections.Generic;

class Program

{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter number: ");
        string numberString = Console.ReadLine();
        int number = int.Parse(numberString);

        int sum = 0;
        int numbersCount = 0;
        int largestNum = 0;

        int smallestPositiveNum = 0;

        if (number != 0)
        {
            numbers.Add(number);
            numbersCount++;

            largestNum = number;

            if (number > 0)
            {
                smallestPositiveNum = number;
            }
        }

        while (number != 0)
        {
            Console.Write("Enter number: ");
            numberString = Console.ReadLine();
            number = int.Parse(numberString);

            if (number != 0)
            {
                numbers.Add(number);
                numbersCount++;

                if (number > largestNum)
                {
                    largestNum = number;
                }

                if ((number > 0) && (number < smallestPositiveNum))
                {
                    smallestPositiveNum = number;
                }
            }
        }

        foreach (int n in numbers)
        {
            sum = sum + n;
        }

        float average = (float)sum / numbersCount;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestPositiveNum}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}