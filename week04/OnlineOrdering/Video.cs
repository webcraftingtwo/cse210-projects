using System;
using System.Collections.Generic;

public class Video
{
    // Attributes
    public string _title;
    public string _author;
    public int _length; // in seconds
    public List<Comment> _comments = new List<Comment>();

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    // Method to add a comment to the list
    public void AddComment(Comment newComment)
    {
        _comments.Add(newComment);
    }

    // Method to return the number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Method to display video details and all comments
    public void DisplayVideoInfo()
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comment Count: {GetCommentCount()}");
        Console.WriteLine("\nComments:");

        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"- {comment._name}: {comment._text}");
        }
        Console.WriteLine("------------------------------------------------");
    }
}
