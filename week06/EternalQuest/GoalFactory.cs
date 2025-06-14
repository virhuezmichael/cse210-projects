public static class GoalFactory
{
    public static Goal CreateFromString(string line)
    {
        string[] parts = line.Split('|');

        if (parts.Length < 4)
        {
            Console.WriteLine("Malformed line in goal file.");
            return null;
        }

        string goalType = parts[0];
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);

        switch (goalType)
        {
            case "SimpleGoal":
                bool isComplete = bool.Parse(parts[4]);
                return new SimpleGoal(name, description, points, isComplete);

            case "EternalGoal":

                return new EternalGoal(name, description, points);

            case "ChecklistGoal":
                
                int targetCount = int.Parse(parts[4]);
                int bonusPoints = int.Parse(parts[5]);
                int currentCount = int.Parse(parts[6]);
                return new ChecklistGoal(name, description, points, targetCount, bonusPoints, currentCount);

            default:
                Console.WriteLine("Unknown goal type: " + goalType);
                return null;
        }
    }
}