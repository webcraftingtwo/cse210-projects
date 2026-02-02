using System;

public class Word {

    private string _text;
    private bool _isHidden;

    public Word(string text) {
        _text  = text;
        _isHidden = false; // word is visible by default
    }
    public void Hide() {
        _isHidden = true;
    }
    
    public void Show() {
        _isHidden = false;
    }

    public bool isHidden() {
        return _isHidden();
    }
    public string GetDisplayText() {
        if(isHidden == false) {
            return _text;
        }
        else {
            string _underscores = "";
            foreach(char letter in _text) {
                _underscores+="_";
            }
            return _underscores;
        }
    }
}