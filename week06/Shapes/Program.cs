using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(5);
        square.SetColor("red");

        Rectangle rectangle = new Rectangle(5, 10);
        rectangle.SetColor("blue");

        Circle circle = new Circle(7);
        circle.SetColor("yellow");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
            Console.WriteLine();
        }
    }
}