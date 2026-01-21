using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
{
    using (StreamWriter outputFile = new StreamWriter(file))
    {
        foreach (Entry entry in _entries)
        {
            // Sanitize inputs: Replaced '|' with '~' so it doesn't break our loader
            string cleanPrompt = entry._promptText.Replace("|", "~");
            string cleanEntry = entry._entryText.Replace("|", "~");
            string cleanMood = entry._mood.Replace("|", "~");
            
            outputFile.WriteLine($"{entry._date}|{cleanPrompt}|{cleanEntry}|{cleanMood}");
        }
    }
}




    public void LoadFromFile(string file)
    {
        _entries.Clear(); // Clear current entries before loading new ones
        
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            // Ensure the line has all 4 parts before trying to use them
            if (parts.Length == 4)
            {
                Entry newEntry = new Entry();
                newEntry._date = parts[0];
                newEntry._promptText = parts[1];
                newEntry._entryText = parts[2];
                newEntry._mood = parts[3];

                _entries.Add(newEntry);
            }
        }
    }
}

