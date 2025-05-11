public class Entry {
    public string _prompt;
    public string _response;
    public string _date;

    public string CompleteEntry() {
        return $"Date: {_date} - Prompt: {_prompt} , {_response}";
    }
}