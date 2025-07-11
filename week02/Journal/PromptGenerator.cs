using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> promptList = new List<string>
    {"Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What goals did I work on today?",
        "What challenged me today and how did I respond?",
        "What did I learn today?",
        "What made me smile or laugh today?",
        "If today were a chapter in a book, what would the title be?",
        "What do I want to remember about today?",
        "Was there a moment I felt peace today?",
        "What would I like to improve tomorrow?",
        "Who did I help or serve today, and how?"
    };

    public PromptGenerator()
    {

    }

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(promptList.Count);
        return promptList[index];
    }
}