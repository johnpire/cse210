using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;
        string[] wordList = text.Split(" ");
        foreach (string word in wordList)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random randomGenerator = new Random();
        var visibleWords = _words.Where(word => word.IsHidden() == false).ToList();

        numberToHide = Math.Min(numberToHide, visibleWords.Count);

        while (numberToHide > 0 && visibleWords.Count > 0)
        {
            int randomIndex = randomGenerator.Next(0, visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
            numberToHide--;
        }
    }

    public void ShowAllHidden()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden() == true);
    }
}