using System;
using System.Net.Sockets;

public class Word
{
    private string _text;
    private bool isHidden;

    public Word(string text)
    {
        _text = text;
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public void Show()
    {
        isHidden = false;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        if (isHidden == true)
        {
            return new string('_', _text.Length);
        }
        else return _text;
    }
}