using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _availableQuestions;
    private Random _random;

    public ReflectingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        _random = new Random();

        _prompts = new List<string>{
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a fear.",
            "Think of a time when you worked with someone very different from you.",
            "Think of a time when you accomplished something you once thought was impossible."
        };

        _questions = new List<string>{
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "What challenges did you face during this experience, and how did you overcome them?",
            "If you could relive this experience, what would you do differently?",
            "How did this experience affect your relationship with others involved?",
            "What skills did you use or develop during this experience?",
            "Did this experience change any of your beliefs or perspectives?"
        };

        _availableQuestions = new List<string>(_questions);
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

        DisplayPrompt();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        string input = Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.WriteLine("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        string selectedPrompt = _prompts[_random.Next(_prompts.Count())];
        return selectedPrompt;
    }

    private string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
        {
            _availableQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_availableQuestions.Count);
        string question = _availableQuestions[index];
        _availableQuestions.RemoveAt(index);

        return question;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {GetRandomPrompt()} ---\n");
    }
    
    private void DisplayQuestion()
    {
        Console.Write($"> {GetRandomQuestion()} ");
        ShowSpinner(15);
        Console.WriteLine();
    }
}

