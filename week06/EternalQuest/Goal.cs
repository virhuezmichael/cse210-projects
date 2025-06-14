public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;


    public virtual string GetDetailsString()
    {
        return $"{_name} ({_description}) - {_points} points";
    }


    public abstract int RecordEvent();


    public virtual bool IsComplete() => false;
    public virtual string GetStringRepresentation()
    {
        return $"{_name},{_description},{_points}";
    }
}