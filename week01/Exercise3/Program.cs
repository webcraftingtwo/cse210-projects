using System;

class Program
{
    static void Main(string[] args)
    {
        // Stretch Challenge 2: Add a loop to play again
        string response = "yes";

        while (response == "yes")
        {
            // Core Requirement 3: Generate a random number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int count = 0; // Stretch Challenge 1: Variable to count guesses

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                
                // Add 1 to the count for every guess
                count = count + 1;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Stretch Challenge 1: Tell them how many guesses it took
            Console.WriteLine($"It took you {count} guesses.");

            // Stretch Challenge 2: Ask if they want to play again
            Console.Write("Do you want to play again? ");
            response = Console.ReadLine();
        }
        
        Console.WriteLine("Thanks for playing!");
    }
}
