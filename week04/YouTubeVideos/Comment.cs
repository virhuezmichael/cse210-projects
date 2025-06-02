public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        this._commenterName = commenterName;
        this._text = text;
    }
    public string GetCommenterName()
    {
        return _commenterName;
    }
    public string GetText()
    {
        return _text;
    }
    public void DisplayComment()
    {
        Console.WriteLine(_commenterName + " says: " + _text);
    }
}