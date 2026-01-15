using System; 

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        // Core Requirement: Determine Letter
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge 1: Determine Sign
        string sign = "";
        int lastDigit = percent % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // Stretch Challenge 2 & 3: Handle Exceptions
        if (letter == "A" && sign == "+")
        {
            sign = ""; // There is no A+
        }
        
        if (letter == "F")
        {
            sign = ""; // There is no F+ or F-
        }

        // Print final result with the sign
        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        // Core Requirement: Pass/Fail Check
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
