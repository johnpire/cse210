using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entry;
    public string _tag;

    public Entry()
    {

    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} — Prompt: {_promptText}");
        Console.WriteLine($"{_entry}\nTag: {_tag}\n");
        
    }
}