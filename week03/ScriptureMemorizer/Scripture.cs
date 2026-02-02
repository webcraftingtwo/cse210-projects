using System;
using System.Collections.Generic;

public class Scripture {
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text) {
        _reference = reference;
        _words = new List<Word>();

        // split the text into a list of strings
        string[] splitText = text.Split(' ');
        
        // turn each string into a Word object and add to list
        foreach (string part in splitText) {
            Word newWord = newWord(part);
            _words.Add(newWord);
        }
    }
    public void HideRandomWords(int numberToHide) {
        Random random = new Random();

        for(int i = 0; i < numberToHide; i++ ) {
            // pick a random index
            int index = random.Next(_words.Count);

            // tell that specific word to hide
            _words[index].Hide();
        }
    }
    public string GetDisplayText() {
        // get reference text
        string scriptureText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words) {
            scriptureText += word.GetDisplayText() + " ";    
        }
        return scriptureText;
    }

    public bool isCompletelyHidden() {
        // check every single word
        foreach (Word word in _words) {
            if (word.isHidden() == false) {
                return false; // if we find even one visible word we are nott done
            }
        }
        return true;           
    }
}