using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create a list to hold the videos
        List<Video> videos = new List<Video>();

        // 2. Create Video 1 and its comments
        Video video1 = new Video("C# Programming 101", "DevGuru", 600);
        video1.AddComment(new Comment("User1", "This really helped me understand classes!"));
        video1.AddComment(new Comment("CoderX", "Great explanation, thanks."));
        video1.AddComment(new Comment("Newbie", "Can you do a video on lists next?"));
        videos.Add(video1);

        // 3. Create Video 2 and its comments
        Video video2 = new Video("Top 10 Coding Mistakes", "TechLife", 450);
        video2.AddComment(new Comment("DevDave", "I'm guilty of #3 for sure."));
        video2.AddComment(new Comment("Alice", "Video was too short but good info."));
        video2.AddComment(new Comment("Bob", "Audio quality could be better."));
        videos.Add(video2);

        // 4. Create Video 3 and its comments
        Video video3 = new Video("Day in the Life of a Software Engineer", "CareerPath", 1200);
        video3.AddComment(new Comment("FutureDev", "So inspiring!"));
        video3.AddComment(new Comment("Student99", "Do you really drink that much coffee?"));
        video3.AddComment(new Comment("Anon", "Nice setup."));
        videos.Add(video3);

        // 5. Iterate through the list and display info
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
