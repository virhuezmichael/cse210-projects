class BreathingActivity : Activity
{
    public void Run()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your brething.";

        base.Run();

        int interval = 6;
        int elapsed = 0;
        while (elapsed < _seconds)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            ShowCountDown(4);
            Console.WriteLine();

            elapsed += interval;
        }

        EndingMessage();

        Thread.Sleep(5000);

    }
}