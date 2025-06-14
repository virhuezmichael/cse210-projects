using System;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;
    static string saveFile = "goals.txt";
    static void Main(string[] args)
    {
         LoadGoals();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Goals ===");
            Console.WriteLine($"Total Points: {totalPoints}");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. Show goals");
            Console.WriteLine("3. Register new event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choise an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoalMenu();
                    break;
                case "2":
                    ShowGoals();
                    Pause();
                    break;
                case "3":
                    RegisterEvent();
                    break;
                case "4":
                    SaveGoals();
                    Pause();
                    break;
                case "5":
                    LoadGoals();
                    Pause();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    static void CreateGoalMenu()
    {
        Console.Clear();
        Console.WriteLine("Create new goal:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Check list");
        Console.Write("Choise type of goal: ");
        string type = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        int points = ReadInt("Points per event: ");

        Goal newGoal = null;

        switch (type)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                int targetCount = ReadInt("Number of times to complete: ");
                int bonusPoints = ReadInt("Bonus upon completion of the goal: ");
                newGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid type.");
                Pause();
                return;
        }

        goals.Add(newGoal);
        Console.WriteLine("Goal created.");
        Pause();
    }

    static void ShowGoals()
    {
        Console.Clear();
        Console.WriteLine("Gaols list:");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals.");
            return;
        }

        int i = 1;
        foreach (var goal in goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }

    static void RegisterEvent()
    {
        ShowGoals();
        if (goals.Count == 0)
        {
            Pause();
            return;
        }

        int choice = ReadInt("Choise the number of goal to register an event: ");
        if (choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid option.");
            Pause();
            return;
        }

        Goal selectedGoal = goals[choice - 1];
        int pointsGained = selectedGoal.RecordEvent();
        totalPoints += pointsGained;

        Console.WriteLine($"Event registered. Points earned : {pointsGained}");
        Console.WriteLine($"Total points: {totalPoints}");
        Pause();
    }

    static int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
        {
            Console.Write("Invalid entry. " + prompt);
        }
        return value;
    }

    static void Pause()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(saveFile))
        {
            writer.WriteLine(totalPoints);
            foreach (var goal in goals)
            {
                // Guardamos con formato sencillo separando campos con '|'
                if (goal is SimpleGoal sg)
                {
                    writer.WriteLine($"SimpleGoal|{sg.GetName()}|{sg.GetDescription()}|{sg.GetPoints()}|{sg.IsComplete()}");
                }
                else if (goal is EternalGoal eg)
                {
                    writer.WriteLine($"EternalGoal|{eg.GetName()}|{eg.GetDescription()}|{eg.GetPoints()}");
                }
                else if (goal is ChecklistGoal cg)
                {
                    // Para ChecklistGoal accedemos a sus campos privados con reflexión o hacemos propiedades públicas, aquí usaré propiedad
                    var typeCg = cg.GetType();
                    var currentCount = (int)typeCg.GetField("_currentCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(cg);
                    var targetCount = (int)typeCg.GetField("_targetCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(cg);
                    var bonusPoints = (int)typeCg.GetField("_bonusPoints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(cg);

                    writer.WriteLine($"ChecklistGoal|{cg.GetName()}|{cg.GetDescription()}|{cg.GetPoints()}|{targetCount}|{bonusPoints}|{currentCount}");
                }
            }
        }
        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        goals.Clear();
        totalPoints = 0;

        if (!File.Exists(saveFile))
        {
            Console.WriteLine("Save file not found.");
            Pause();
            return;
        }

        string[] lines = File.ReadAllLines(saveFile);
        if (lines.Length == 0)
        {
            Console.WriteLine("Empty file.");
            Pause();
            return;
        }

        int.TryParse(lines[0], out totalPoints);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            if (parts.Length == 0) continue;

            string type = parts[0];
            try
            {
                switch (type)
                {
                    case "SimpleGoal":
                        if (parts.Length == 5)
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.Parse(parts[3]);
                            bool isComplete = bool.Parse(parts[4]);
                            goals.Add(new SimpleGoal(name, description, points, isComplete));
                        }
                        break;
                    case "EternalGoal":
                        if (parts.Length == 4)
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.Parse(parts[3]);
                            goals.Add(new EternalGoal(name, description, points));
                        }
                        break;
                    case "ChecklistGoal":
                        if (parts.Length == 7)
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.Parse(parts[3]);
                            int targetCount = int.Parse(parts[4]);
                            int bonusPoints = int.Parse(parts[5]);
                            int currentCount = int.Parse(parts[6]);
                            goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints, currentCount));
                        }
                        break;
                }
            }
            catch
            {
                Console.WriteLine($"Error reading line {i + 1} from file.");
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}