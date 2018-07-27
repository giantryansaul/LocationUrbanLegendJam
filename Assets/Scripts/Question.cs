using System;

[Serializable]
public class Question
{
    private string _lore; //question
    private string _answer; //answer 

    public Question(string NewLore, string NewAnswer) //if pulling for a string
    {
        _lore = NewLore;
        _answer = NewAnswer;
    }
    public Question(Question NewLegend) //if pulling from a list 
    {
        _lore = NewLegend._lore;
        _answer = NewLegend._answer;
    }

    public string GetLore()
    {
        return _lore;
    }
    public string GetAnswer()
    {
        return _answer;
    }
    private void Start()
    {
            
    }
}