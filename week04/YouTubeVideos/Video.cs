using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    private int CountComments()
    {
        return _comments.Count;
    }

    public void DisplayAll()
    {
        int i = 1;
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Video Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {CountComments()}");
        Console.WriteLine();

        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"Comment {i++}");
            comment.Display();
        }

        Console.WriteLine();
    }
}

