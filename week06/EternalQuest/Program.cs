using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // 1. Added a Leveling System: The player displays a rank (Novice, Apprentice, etc.) 
        //    based on their total score.
        // 2. Added input validation to ensure the program doesn't crash if bad data is entered.

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
