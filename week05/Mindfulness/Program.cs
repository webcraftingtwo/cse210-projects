using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

/*
 * Author: Tanatswa Mbewe
 * Course: CSE 210 - Programming with Classes
 * Assignment: Week 05 Mindfulness Program
 * * Exceeding Requirements:
 * 1. Persistence: The program saves and loads the total number of sessions completed 
 * to a file named "log.txt" so that progress is tracked across different runs.
 * 2. Input Validation: Added a check for the duration input to ensure the program 
 * doesn't crash if a user enters non-numeric text.
 */

// --- BASE CLASS ---
public abstract class Activity
{
    // Encapsulation: Private member variables
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        
        // Input validation for robustness
        if (!int.TryParse(Console.ReadLine(), out _duration))
        {
            _duration = 30; 
        }
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        // Using the backspace technique from assignment documentation
        List<string> animationCharacters = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animationCharacters[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= animationCharacters.Count) i = 0;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();
}

// --- CHILD CLASS: BREATHING ---
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            Console.Write("\nNow breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}

// --- CHILD CLASS: REFLECTING ---
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?"
    };

    public ReflectingActivity() : base("Reflecting Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    public override void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();
        
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"\n --- {_prompts[random.Next(_prompts.Count)]} --- ");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"> {_questions[random.Next(_questions.Count)]} ");
            ShowSpinner(7);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}

// --- CHILD CLASS: LISTING ---
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {}

    public override void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();
        Console.WriteLine("List as many items as you can to the following prompt:");
        Console.WriteLine($" --- {_prompts[random.Next(_prompts.Count)]} --- ");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userList = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                userList.Add(item);
            }
        }

        Console.WriteLine($"You listed {userList.Count} items!");
        DisplayEndingMessage();
    }
}

// --- MAIN PROGRAM ---
class Program
{
    private static string _logFile = "log.txt";

    static void Main(string[] args)
    {
        int totalSessions = LoadLog();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine($"\n[Progress: {totalSessions} total sessions completed]");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
            }

            if (activity != null)
            {
                activity.Run();
                totalSessions++;
                SaveLog(totalSessions);
            }
        }
    }

    static int LoadLog()
    {
        if (File.Exists(_logFile))
        {
            string value = File.ReadAllText(_logFile);
            if (int.TryParse(value, out int count)) return count;
        }
        return 0;
    }

    static void SaveLog(int count)
    {
        File.WriteAllText(_logFile, count.ToString());
    }
}
