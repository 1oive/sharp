using System;

// Определим интерфейс для вычисления площади фигуры
public interface IAreaCalculable
{
    double CalculateArea();
}

// Базовый класс для всех фигур
public abstract class Fugure : IAreaCalculable
{
    public string name { get; set; }

    protected Fugure(string name)
    {
        this.name = name;
    }

    // Абстрактный метод для вычисления площади
    public abstract double CalculateArea();

    public override string ToString()
    {
        return $"{name} с площадью: {CalculateArea()}";
    }
}

// Класс для прямоугольника
public class Rectangle : Fugure
{
    public double a { get; set; }
    public double b { get; set; }

    public Rectangle(double a, double b)
        : base("Прямоугольник")
    {
        this.a = a;
        this.b = b;
    }

    public override double CalculateArea()
    {
        return a * b;
    }
}

// Класс для треугольника
public class Triangle : Fugure
{
    public double a { get; set; }
    public double h { get; set; }

    public Triangle(double a, double h)
        : base("Треугольник")
    {
        this.a = a;
        this.h = h;
    }

    public override double CalculateArea()
    {
        return 0.5 * a * h;
    }
}

// Класс для круга
public class Circle : Fugure
{
    public double Radious { get; set; }

    public Circle(double r)
        : base("Круг")
    {
        this.Radious = r;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radious * Radious;
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        Fugure rectangle = new Rectangle(5, 10);
        Fugure triangle = new Triangle(4, 6);
        Fugure circle = new Circle(7);

        Console.WriteLine(rectangle);
        Console.WriteLine(triangle);
        Console.WriteLine(circle);
    }
}