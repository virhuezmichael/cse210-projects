using System;
using System.Collections.Generic;

public class PromptMaker {
    public List<string> _availablePrompts;
    public Random _ramndom = new Random();

    public PromptMaker () {
        _availablePrompts = new List<string>
        {
            "What was the best part of your day?",
            "Did something surprise you today?",
            "What's the most interesting thing you've learned recently?",
            "What's the best advice you've ever received?",
            "What's the most challenging thing you've faced recently?",
            "Describe a small moment that made you smile today.."
        };
    }
    public string GetPrompt() {
        if (_availablePrompts.Count == 0) {
            return "You've answered all the prompts for today! Feel free to come back tomorrow for new reflections.";
        }

        int index = _ramndom.Next(_availablePrompts.Count);
        string prompt = _availablePrompts[index];
        _availablePrompts.RemoveAt(index);
        return prompt;
    }
}