using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string UserName = Console.ReadLine();
            return UserName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string UserFavNumString = Console.ReadLine();
            int UserFavNum = int.Parse(UserFavNumString);
            return UserFavNum;
        }

        static int SquareNumber(int number)
        {
            int numberSquared = number * number;
            return numberSquared;
        }

        static void DisplayResult(string name, int number)
        {
            Console.WriteLine($"{name}, the square root of your number is {number}");
        }

        DisplayWelcome();
        string nameUser = PromptUserName();
        int favoriteNum = PromptUserNumber();
        int squaredNum = SquareNumber(favoriteNum);
        DisplayResult(nameUser, squaredNum);
    }
}