using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public Journal()
    {

    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count != 0)
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        else
        {
            Console.WriteLine("There is currently no content.\n");
        }
    }

    public void SaveToFile(string journalFile)
    {
        using (StreamWriter outputFile = new StreamWriter(journalFile))
        {
            foreach (Entry entry in _entries)
            {
                string entryString = $"{entry._date}|{entry._promptText}|{entry._entry}|{entry._tag}";
                outputFile.WriteLine(entryString);
            }
        }
    }

    public void LoadFromFile(string journalFile)
    {
        _entries.Clear();
        
        string[] lines = System.IO.File.ReadAllLines(journalFile);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry loadedEntry = new Entry();
            loadedEntry._date = parts[0];
            loadedEntry._promptText = parts[1];
            loadedEntry._entry = parts[2];
            loadedEntry._tag = parts[3];

            _entries.Add(loadedEntry);
        }
    }
}