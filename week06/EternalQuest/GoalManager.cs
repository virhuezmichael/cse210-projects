public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        int points = _goals[goalIndex].RecordEvent();
        _score += points;
        Console.WriteLine($"¡Event registered! You win {points} points.");
    }
    public void DisplatScore()
    {
        Console.WriteLine($"Your current score is {_score}.");
    }
    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Metas guardadas correctamente.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Archivo no encontrado.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal loadedGoal = GoalFactory.CreateFromString(lines[i]);
            if (loadedGoal != null)
            {
                _goals.Add(loadedGoal);
            }
        }

        Console.WriteLine("Metas cargadas correctamente.");
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }
}