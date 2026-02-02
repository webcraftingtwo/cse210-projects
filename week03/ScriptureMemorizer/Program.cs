using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements
        // instead of one scripture , we have a list of them
        List<Scripture> scriptureLibrary = new List<Scripture>();

        // new scriptures to our library
        Reference r1 = new Reference("John",3,16);
        Scripture s1 = new Scripture(r1, "For God so loved the world that he gave his one and only Son, that whosoever believes in him shall not perish but have eternal life.");
        
        Reference r2 = new Reference("Proverbs",3,5,6);
        Scripture s2 = new Scripture(r2, "Trust in the Lord with all your heart and lean not on your own understanding, in all your ways submit to him, and he will make your paths straight.");

        Reference r3 = new Reference("D&C",6,36);
        Scripture s3 = new Scripture(r3, "Look unto me in every thought; doubt not; fear not.");

        scriptureLibrary.Add(s1);
        scriptureLibrary.Add(s2);
        scriptureLibrary.Add(s3);

        // pick one at random
        Random random = new Random();
        int index  = random.Next(scriptureLibrary.Count);
        Scripture selectedScripture = scriptureLibrary[index];

        // loop starts 
        string input = "";
        while(input != "quit" && selectedScripture.isCompletelyHidden()==false ) {
            Console.Clear();

            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue or type 'quit' to finish" );

            input = Console.ReadLine();
            if(input != "quit") {
                selectedScripture.HideRandomWords(3);
            }
        } 
        Console.Clear();
        Console.WriteLine("Scripture Memorized!");
        Console.WriteLine(selectedScripture.GetDisplayText());
    }
}