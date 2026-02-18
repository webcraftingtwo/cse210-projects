public class Square : Shape
{
    private double _side;

    // Pass color to the base constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}
