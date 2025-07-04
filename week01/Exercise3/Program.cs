using System;

class Program
{
    static void Main(string[] args)
    {
        string play = "y";
        while (play == "y")
        {
            Random randomGenerator = new Random();
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();

            int number = randomGenerator.Next(1, 100);
            int guessInt = int.Parse(guess);

            int guessCount = 0;

            while (guessInt != number)
            {
                if (guessInt > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guessInt < number)
                {
                    Console.WriteLine("Higher");
                }
                if (guessInt != number)
                {
                    Console.Write("What is your guess? ");
                    guess = Console.ReadLine();
                    guessInt = int.Parse(guess);
                }

                guessCount++;
            }

            Console.WriteLine("You guessed it!");

            guessCount++;
            Console.WriteLine($"It took you {guessCount} guesses.");

            Console.Write("Do you want to play again? (y/n)");
            play = Console.ReadLine();

            while (play != "y" && play != "n")
            {
                Console.WriteLine("Please only types (y/n)");
                Console.Write("Do you want to play again? (y/n) ");
                play = Console.ReadLine();
            }
        }
    }
}