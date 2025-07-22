using System;
using System.Collections.Generic;

public class ScriptureLoader
{
    private List<Scripture> _scriptures = new List<Scripture>();

    public void LoadFromFile(string scripturesFile)
    {
        string[] lines = System.IO.File.ReadAllLines(scripturesFile);

        // Example: John|3:16-17|For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            string book = parts[0];

            string[] chapterAndVerse = parts[1].Split(":");
            int chapter = int.Parse(chapterAndVerse[0]);

            string[] verses = chapterAndVerse[1].Split("-");
            int verseStart = int.Parse(verses[0]);

            Reference reference;
            if (verses.Length > 1)
            {
                int verseEnd = int.Parse(verses[1]);

                reference = new Reference(book, chapter, verseStart, verseEnd);
            }

            else
            {
                reference = new Reference(book, chapter, verseStart);
            }

            string text = parts[2];
            Scripture scripture = new Scripture(reference, text);

            _scriptures.Add(scripture);
        }
    }

    public Scripture GetRandomScripture()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_scriptures.Count);
        return _scriptures[index];
    }

    public List<Scripture> GetAllScriptures()
    {
        return _scriptures;
    }
}