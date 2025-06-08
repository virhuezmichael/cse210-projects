class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "When have you felt the Spirit this month?",
        "Who are some of your personal heroes?"
    };

    public void Run()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        base.Run();

        Random rand = new();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine("\nStart listing items. Press Enter after each. Time starts now!");

        List<string> entries = new();
        DateTime endTime = DateTime.Now.AddSeconds(_seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            if (DateTime.Now < endTime)
            {
                string input = Console.ReadLine();
                entries.Add(input);
                _count = entries.Count;
            }
        }

        Console.WriteLine($"\nYou listed {_count} items!");
        EndingMessage();
        
        Thread.Sleep(5000);
    }
    public string GetRandomPrompt()
    {
        return "hello";
    }
    public List<string> GetListFromUser()
    {
        List<string> lista = new List<string>() {"hello", "chau"};
        return lista;
    }
}