// Addition:
// 1) Added Prompts and Questions to the existing lists
// 2) Added a system that will track how many activities and how many seconds in total has been done by the user. This is presented as another option in the menu.
// 3) Added a system for ReflectingActivity class so that the randomizer method doesn't show duplicate questions.
// 4) Made sure the ShowCountDown method in Activity will function properly no matter the digit number.

using System;

class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity();
        int totalActivities = 0;
        int totalTime = 0;

        while (true)
        {
            Console.Clear();
            Console.Write("Menu Options:\n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. Show number of completed activities\n  5. Quit\nSelect a choice from the menu: ");
            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity",
                "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0);
                breathingActivity.Run();

                int duration = breathingActivity.GetDuration();
                totalActivities++;
                totalTime += duration;
            }
            else if (userChoice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting Activity",
                "This activity will help you reflect on times in your life when you have shown strength and resilience.This will help you recognize the power you have and how you can use it in other aspects of your life.",
                0);
                reflectingActivity.Run();

                int duration = reflectingActivity.GetDuration();
                totalActivities++;
                totalTime += duration;
            }
            else if (userChoice == "3")
            {
                ListingActivity listingActivity = new ListingActivity("Listing Activity",
                "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0);
                listingActivity.Run();

                int duration = listingActivity.GetDuration();
                totalActivities++;
                totalTime += duration;
            }
            else if (userChoice == "4")
            {
                Console.Clear();
                Console.WriteLine($"Activities completed: {totalActivities}");
                Console.WriteLine($"Total time spent: {totalTime} seconds");
                Console.Write("\nPress 'enter' to continue\n");
                string input = Console.ReadLine();
            }
            else if (userChoice == "5")
            {
                Console.WriteLine("Exiting the Program.\n");
                break;
            }
            else
            {
                Console.WriteLine("\nPlease only input numbers from the provided options.");
                activity.ShowCountDown(5);
            }
        }
    }
}