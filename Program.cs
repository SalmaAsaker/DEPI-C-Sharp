//-1----------------------------
using System;
/*struct Point
{
    public int X;
    public int Y;

    // parameterized constructor
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}
class Program
{
    static void Main()
    {
        Point p = new Point(3, 4);
        Console.WriteLine(p);
    }
}
/*Why structs cannot inherit?
Structs are value types stored directly in memory. Inheritance would introduce:
hidden reference behavior
polymorphism overhead
unpredictable memory layout
So C# restricts structs to inherit only from System.ValueType*/
//----------------------------------------------------------------------------------*/
//-2-----------------------------------------
/*class TypeA
{
    private int F = 10;
    internal int G = 20;
    public int H = 30;

    public void Show()
    {
        Console.WriteLine(F); // allowed
    }
}
class Program
{
    static void Main()
    {
        TypeA obj = new TypeA();

        // obj.F ❌ private
        Console.WriteLine(obj.G); // internal
        Console.WriteLine(obj.H); // public
    }
}
/*Impact of access modifiers
Access modifiers control:

Modifier Visibility
private inside class only
internal same assembly
public everywhere
They protect data and enforce safe design*/
//------------------------------------------------------------------------*/
//-3----------------------------------------------------
/*struct Employee
{
    private int empId;
    private string name;
    private double salary;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public void SetData(int id, double sal)
    {
        empId = id;
        salary = sal;
    }

    public void Display()
    {
        Console.WriteLine($"{empId} - {name} - {salary}");
    }
}
class Program
{
    static void Main()
    {
        Employee emp = new Employee();
        emp.Name = "Salma";
        emp.SetData(1, 5000);
        emp.Display();
    }
}
/*Why encapsulation is critical?
Encapsulation:

 protects data
 prevents invalid changes
 improves maintainability
 enforces business rules*/
//-----------------------------------------------------*/
//-4-------------------------------------------------------------------
/*struct Point
{
    public int X;
    public int Y;

    public Point(int x)
    {
        X = x;
        Y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(5);
        Point p2 = new Point(3, 4);

        Console.WriteLine($"{p1.X}, {p1.Y}");
        Console.WriteLine($"{p2.X}, {p2.Y}");
    }
}
/* What are constructors in structs?
Constructors initialize struct fields.

Rules:

 must initialize ALL fields
 default constructor exists automatically
 support overloading*/
//-------------------------------------------------------*/
//-5-------------------------------------
/*struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"Point → X:{X} | Y:{Y}";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(new Point(1, 2));
        Console.WriteLine(new Point(5, 8));
    }
}
/* Why override ToString?
 improves debugging
 readable output
 meaningful logs*/

//--------------------------------------------*/
//-6--------------------------------
/* struct Point
{
    public int X;
}

class Employee
{
    public int Salary;
}
class Program
{
    static void ModifyPoint(Point p)
    {
        p.X = 100;
    }

    static void ModifyEmployee(Employee e)
    {
        e.Salary = 10000;
    }

    static void Main()
    {
        Point pt = new Point { X = 1 };
        Employee emp = new Employee { Salary = 2000 };

        ModifyPoint(pt);
        ModifyEmployee(emp);

        Console.WriteLine(pt.X);     // unchanged
        Console.WriteLine(emp.Salary); // changed
    }
}
/*Memory difference
Struct	Class
stack	heap
copied by value	passed by reference
lightweight	flexible*/
//------------------------------------*/