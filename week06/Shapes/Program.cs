using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create a list to hold shapes (Polymorphism in action)
        List<Shape> shapes = new List<Shape>();

        // 2. Add instances of Square, Rectangle, and Circle
        Square s1 = new Square("Red", 4);
        Rectangle r1 = new Rectangle("Blue", 5, 3);
        Circle c1 = new Circle("Green", 2.5);

        shapes.Add(s1);
        shapes.Add(r1);
        shapes.Add(c1);

        // 3. Iterate and display areas
        foreach (Shape shape in shapes)
        {
            // The correct GetArea() is called based on the object type, not the variable type
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area:F2}");
        }
    }
}
