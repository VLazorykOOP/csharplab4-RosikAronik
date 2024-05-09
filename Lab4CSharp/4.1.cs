using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Student : Person
{
    public string StudentID { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Student ID: {StudentID}, Name: {Name}, Age: {Age}");
    }
}

class Teacher : Person
{
    public string Subject { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Subject: {Subject}, Name: {Name}, Age: {Age}");
    }
}

class DepartmentHead : Teacher
{
    public string Department { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Department: {Department}, Subject: {Subject}, Name: {Name}, Age: {Age}");
    }
}

class Point
{
    private int x;
    private int y;
    private readonly int color;

    public Point()
    {
        x = 0;
        y = 0;
        color = 0;
    }

    public Point(int x, int y, int color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    public void DisplayCoordinates()
    {
        Console.WriteLine($"Coordinates: ({x}, {y}), Color: {color}");
    }

    public double DistanceToOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void Move(int x1, int y1)
    {
        x += x1;
        y += y1;
    }

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public int Color
    {
        get { return color; }
    }

    // Indexer
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return x;
                case 1: return y;
                case 2: return color;
                default:
                    Console.WriteLine("Error: Invalid index!");
                    return -1;
            }
        }
    }

    // Overloading operators
    public static Point operator ++(Point p)
    {
        p.x++;
        p.y++;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.x--;
        p.y--;
        return p;
    }

    public static bool operator true(Point p)
    {
        return (p.x != 0 || p.y != 0);
    }

    public static bool operator false(Point p)
    {
        return (p.x == 0 && p.y == 0);
    }

    public static Point operator +(Point p, int scalar)
    {
        p.x += scalar;
        p.y += scalar;
        return p;
    }

    public static explicit operator string(Point p)
    {
        return $"({p.x}, {p.y}), Color: {p.color}";
    }

    public static explicit operator Point(string s)
    {
        // Assuming input format: "(x, y), Color: color"
        string[] parts = s.Split(new char[] { '(', ',', ')', ':' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 4)
        {
            throw new ArgumentException("Invalid string format");
        }

        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);
        int color = int.Parse(parts[3]);

        return new Point(x, y, color);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        people.Add(new Student { Name = "John", Age = 20, StudentID = "S001" });
        people.Add(new Teacher { Name = "Jane", Age = 35, Subject = "Math" });
        people.Add(new DepartmentHead { Name = "David", Age = 45, Subject = "Physics", Department = "Science" });

        people.Sort((p1, p2) => string.Compare(p1.Name, p2.Name));

        Console.WriteLine("People:");
        foreach (var person in people)
        {
            person.Show();
        }

        Point point = new Point(3, 4, 255);
        Console.WriteLine("\nPoint:");
        point.DisplayCoordinates();
        Console.WriteLine($"Distance to origin: {point.DistanceToOrigin()}");

        Console.WriteLine("\nIndexer:");
        Console.WriteLine($"x: {point[0]}, y: {point[1]}, color: {point[2]}");

        Console.WriteLine("\nOverloaded operators:");
        Point p1 = new Point(1, 2, 0);
        Console.WriteLine($"Initial: {p1}");
        p1++;
        Console.WriteLine($"After ++: {p1}");
        p1--;
        Console.WriteLine($"After --: {p1}");
        p1 = p1 + 5;
        Console.WriteLine($"After + 5: {p1}");

        Console.WriteLine("\nConversion:");
        string pointString = "(10, 20), Color: 128";
        Point p2 = (Point)pointString;
        Console.WriteLine($"Converted from string: {p2}");
    }
}
