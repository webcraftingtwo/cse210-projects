public class Shape
{
    private string _color;

    // Constructor accepting color
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Setter for color
    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method to be overridden by derived classes
    public virtual double GetArea()
    {
        return 0;
    }
}
