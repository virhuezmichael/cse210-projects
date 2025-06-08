class Activity
{
    protected string _name;
    protected string _description;
    protected int _seconds;
    public void Run(){
        DisplayStartingMessage();
        SetSeconds();
        Console.WriteLine("Prepare to begin..");
        ShowSpinner(3);
    }

    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public int GetSeconds()
    {
        return _seconds;
    }
    public void SetSeconds()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _seconds = int.Parse(Console.ReadLine());
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine(_description);
        Console.WriteLine();
    }
    public void EndingMessage()
    {
        Console.WriteLine("Well Done!");
        Console.WriteLine($"You have completed another {_seconds} seconds of the {_name} Activity");
    }
    public void ShowSpinner(int seconds)
    {
         var symbols = new[] { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(symbols[i % symbols.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
        }
    }
    public void ShowCountDown(int second)
    {
        for (int i = second; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

}