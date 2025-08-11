using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    // removed _count, but instead use .Count for practicality
    private List<string> _prompts;
    private Random _random;

    public ListingActivity  (string name, string description, int duration) : base(name, description, duration)
    {
        _random = new Random();

        _prompts = new List<string>{
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What is something you accomplished recently that you are proud of?",
            "When was a time you overcame a difficult challenge?",
            "Who in your life inspires you to be better?",
            "What blessings are you most grateful for today?",
            "When was the last time you felt true peace?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        string userDuration = Console.ReadLine();
        _duration = int.Parse(userDuration);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();

        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {prompt} ---");

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> items = GetListFromUser();
        
        Console.WriteLine($"You listed {items.Count} items!\n");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            items.Add(input);
        }

        return items;
    }
}

