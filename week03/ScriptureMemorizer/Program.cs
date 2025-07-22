// I completed the Stretch Challenge where the program will only have to hide unhidden words.
// I added a class 'ScriptureLoader' that loads a list of scriptures from a text file, which will randomize which scripture to utilize instead of being hardcoded in the code.
// I looped the program so that it will ask again if it wants the user to try again with random scripture from the text file.
// I added more text interactions.

using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLoader scriptureList = new ScriptureLoader();

        Console.Write("Please enter the name of the file containing the scriptures: ");
        string scriptures = Console.ReadLine();
        scriptureList.LoadFromFile(scriptures);

        while (true)
        {
            scriptureList.GetAllScriptures();
            Scripture scripture = scriptureList.GetRandomScripture();

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            bool isHidden = scripture.IsCompletelyHidden();
            while (isHidden == false)
            {
                Console.WriteLine($"\nPress enter to continue or type 'quit' to finish:");
                string input = Console.ReadLine();
                Console.Clear();

                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("Quitting the Program!");
                    break;
                }

                scripture.HideRandomWords(3);
                Console.WriteLine(scripture.GetDisplayText());

                isHidden = scripture.IsCompletelyHidden();
            }
            Console.WriteLine($"\nAll words are now hidden! Were you able to recite it fully?");

            Console.Write("Do you want to try different scripture from the list? (y/n) ");
            string tryAgain = Console.ReadLine().ToLower();
            while (tryAgain != "y" && tryAgain != "n")
            {
                Console.WriteLine("Please enter 'y' or 'n': ");
                tryAgain = Console.ReadLine().ToLower();
            }

            if (tryAgain == "y")
            {
                scripture.ShowAllHidden();
            }
            else
            {
                Console.WriteLine("Thank you for using the program.");
                break;
            }
        }
    }
}