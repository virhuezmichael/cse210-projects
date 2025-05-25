using System.Reflection.Metadata.Ecma335;

public class Scripture
{

    private List<Word> _words;
    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }
    public void HideRandomWords(int numberToHide)
    {
         var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        var random = new Random();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public string GetDisplayText()
    {
         return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }
    public bool isCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
    
}

    
