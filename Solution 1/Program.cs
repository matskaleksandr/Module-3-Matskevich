using System;

abstract class Shape
{
    public abstract double CalculateArea();
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

class Triangle : Shape
{
    public double BaseLength { get; set; }
    public double Height { get; set; }

    public Triangle(double baseLength, double height)
    {
        BaseLength = baseLength;
        Height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * BaseLength * Height;
    }
}

class Program
{
    delegate double CalculateAreaDelegate();

    static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(4, 7);
        Triangle triangle = new Triangle(3, 6);

        CalculateAreaDelegate circleDelegate = circle.CalculateArea;
        CalculateAreaDelegate rectangleDelegate = rectangle.CalculateArea;
        CalculateAreaDelegate triangleDelegate = triangle.CalculateArea;

        Console.WriteLine("Area of Circle: " + circleDelegate());
        Console.WriteLine("Area of Rectangle: " + rectangleDelegate());
        Console.WriteLine("Area of Triangle: " + triangleDelegate());
    }
}
