class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public new void Run()
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        base.Run();

        
        GetRandomPrompt();
        DisplayPrompt();
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < _seconds)
        {
            GetRandomQuestion();
            DisplayQuestions();
            ShowSpinner(4);
            elapsed += 6;
        }

        EndingMessage();
        
        Thread.Sleep(5000);
    }
    public string GetRandomPrompt()
    {
        Random rand = new();
        return _prompts[rand.Next(_prompts.Count)];
    }
    public string GetRandomQuestion()
    {
        Random rand = new();
        return _questions[rand.Next(_questions.Count)];
    }
    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }
    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
    }
}