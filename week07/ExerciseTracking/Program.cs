using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all activities
        List<Activity> activities = new List<Activity>();

        // Add one of each type of activity
        activities.Add(new Running("03 Nov 2022", 30, 4.8));
        activities.Add(new Cycling("04 Nov 2022", 45, 20.0)); // 20 kph
        activities.Add(new Swimming("05 Nov 2022", 30, 20));  // 20 laps

        // Iterate through the list and call GetSummary() on each
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
