// Exceeding Expectations:
// 1. Improved user interaction with the interface:
//    - Added prompt to save before exiting the program
//    - Added warning and option to save before loading a new file
//    - Prevented saving or loading when there's no content
//    - Added 9 more prompts to the existing list of prompts
//    - Included interactive and user-friendly messages
//
// 2. Added an enhancement to the Entry object by introducing a 'Tag' field:
//    - Added a system where each journal entry can be labeled with a custom tag (e.g. "Gratitude", "Goals", "Stress")
//    - (NOTE that the tag system is simple in accordance with the current overall program. It will be polished upon further updates on the program)

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal userJournal = new Journal();
        Console.WriteLine("Welcome to the Journal Program!");
        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Entry newEntry = new Entry();

                DateTime currentTime = DateTime.Now;
                string timeNow = currentTime.ToShortDateString();
                newEntry._date = timeNow;

                PromptGenerator randomGenerator = new PromptGenerator();
                string prompt = randomGenerator.GetRandomPrompt();
                newEntry._promptText = prompt;

                Console.WriteLine(prompt);
                newEntry._entry = Console.ReadLine();

                Console.WriteLine("Add a tag for this entry to describe its theme (e.g. Goals, Feelings, Family): ");
                newEntry._tag = Console.ReadLine();
                Console.WriteLine();

                userJournal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {

                userJournal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                if (userJournal._entries.Count == 0)
                {
                    loadJournalFromFile(userJournal);
                }
                else
                {
                    Console.WriteLine("You have unsaved entries, Loading a new file will overwrite them.");
                    Console.Write("Do you want to continue loading? (y/n): ");
                    string saveBeforeLoad = Console.ReadLine().ToLower();
                    while (saveBeforeLoad != "y" && saveBeforeLoad != "n")
                    {
                        Console.WriteLine("Please enter 'y' or 'n': ");
                        saveBeforeLoad = Console.ReadLine().ToLower();
                    }

                    if (saveBeforeLoad == "y")
                    {
                        loadJournalFromFile(userJournal);
                    }
                    else
                    {
                        Console.WriteLine("Load cancelled. Your current entries remain unchanged.\n");
                    }
                }
            }
            else if (userChoice == "4")
            {
                Console.Write("\n(Make sure to include the filetype)\nFilename: ");
                string fileName = Console.ReadLine();
                Console.WriteLine();
                userJournal.SaveToFile(fileName);
                Console.WriteLine("Entries saved successfully.");
            }
            else if (userChoice == "5")
            {
                if (userJournal._entries.Count != 0)
                {
                    Console.WriteLine("You have unsaved entries. Would you like to save them before exiting? (y/n)");
                    string saveBeforeQuit = Console.ReadLine().ToLower();
                    while (saveBeforeQuit != "y" && saveBeforeQuit != "n")
                    {
                        Console.Write("Please enter 'y' or 'n': ");
                        saveBeforeQuit = Console.ReadLine().ToLower();
                    }
                    if (saveBeforeQuit == "y")
                    {
                        Console.Write("\n(Make sure to include the filetype)\nFilename: ");
                        string fileName = Console.ReadLine();
                        Console.WriteLine();
                        userJournal.SaveToFile(fileName);
                        Console.WriteLine("Entries saved successfully.");
                    }

                    else
                    {
                        Console.WriteLine("Changes were not saved");
                    }
                }
                else
                {
                    Console.WriteLine("No entries to save.");
                }
                Console.WriteLine("Exiting the Program.\n");
                break;
            }

            else
            {
                Console.WriteLine("Please only input numbers from 1-5.\n");
            }

        }
    }

    static void loadJournalFromFile(Journal journal)
        {
            Console.Write("\n(Make sure to include the filetype and that the file should be in the same folder directory)\nFilename: ");
            string fileName = Console.ReadLine();
            Console.WriteLine();
            journal.LoadFromFile(fileName);
            Console.WriteLine("Entries loaded successfully.\n");
        }

}