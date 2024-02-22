using System;


abstract class Shape
{
    private string color;

    protected Shape(string color)
    {
        this.color = color;
    }

    public abstract void Draw();

    public string Color
    {
        get { return color; }
        set { color = value; }
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius, string color) : base(color)
    {
        this.radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing a " + Color + " circle with radius " + radius);
    }
}

class Square : Shape
{
    private double side;

    public Square(double side, string color) : base(color)
    {
        this.side = side;
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing a " + Color + " square with side " + side);
    }
}

