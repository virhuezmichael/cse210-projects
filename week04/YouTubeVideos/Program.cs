using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<Video> videos = new List<Video>();

       
        Video video1 = new Video("Intro to C#", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        video1.AddComment(new Comment("Charlie", "I learned a lot."));

        Video video2 = new Video("Advanced C# Concepts", "Jane Smith", 1200);
        video2.AddComment(new Comment("Diana", "This was challenging but good."));
        video2.AddComment(new Comment("Evan", "Clear explanations."));
        video2.AddComment(new Comment("Fiona", "Please make more videos like this."));
        video2.AddComment(new Comment("George", "Excellent content!"));

        Video video3 = new Video("C# Design Patterns", "Carlos Ruiz", 900);
        video3.AddComment(new Comment("Hannah", "Design patterns are so useful."));
        video3.AddComment(new Comment("Ivan", "Could you explain Strategy pattern more?"));
        video3.AddComment(new Comment("Julia", "Awesome examples."));

        
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}