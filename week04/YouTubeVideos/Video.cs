public class Video
{
    private string title;
    private string author;
    private int duration; 
    private List<Comment> comments;

    public Video(string title, string author, int duration)
    {
        this.title = title;
        this.author = author;
        this.duration = duration;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Duration (seconds): {duration}");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine(); 
    }
}