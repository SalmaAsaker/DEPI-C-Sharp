// ========================== Part 01 ==========================


// ========================== Q1 ==========================
// Create enum Weekdays with explicit values and print name & value

// enum Weekdays
// {
//     Monday = 1,
//     Tuesday,
//     Wednesday,
//     Thursday,
//     Friday
// }

// foreach (Weekdays day in Enum.GetValues(typeof(Weekdays)))
// {
//     Console.WriteLine($"{day} = {(int)day}");
// }



// ========================== Q2 ==========================
// Modify Grades enum to use short and set F = -1

// enum Grades : short
// {
//     A = 5,
//     B = 4,
//     C = 3,
//     D = 2,
//     F = -1
// }

// foreach (Grades g in Enum.GetValues(typeof(Grades)))
// {
//     Console.WriteLine($"{g} = {(short)g}");
// }



// ========================== Q3 ==========================
// Add Department property to Person and instantiate two objects

// class Person
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
//     public virtual string Department { get; set; }

//     public override string ToString()
//     {
//         return $"{Name} - {Age} - {Department}";
//     }
// }

// Person p1 = new Person { Name = "Ali", Age = 25, Department = "IT" };
// Person p2 = new Person { Name = "Sara", Age = 30, Department = "HR" };

// Console.WriteLine(p1);
// Console.WriteLine(p2);



// ========================== Q4 ==========================
// Extend Child class and use sealed property

// class Child : Person
// {
//     public sealed override string Department { get; set; }

//     public void DisplaySalary()
//     {
//         Console.WriteLine($"Department: {Department}");
//     }
// }

// Child c = new Child { Name = "Omar", Age = 10, Department = "Junior" };
// c.DisplaySalary();



// ========================== Q5 ==========================
// Static method to calculate rectangle perimeter

// static class Utility
// {
//     public static double Perimeter(double length, double width)
//     {
//         return 2 * (length + width);
//     }
// }

// Console.WriteLine(Utility.Perimeter(5, 3));



// ========================== Q6 ==========================
// Operator overloading for multiplication in ComplexNumber

// class ComplexNumber
// {
//     public double Real { get; set; }
//     public double Imag { get; set; }

//     public ComplexNumber(double r, double i)
//     {
//         Real = r;
//         Imag = i;
//     }

//     public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
//     {
//         return new ComplexNumber(
//             a.Real * b.Real - a.Imag * b.Imag,
//             a.Real * b.Imag + a.Imag * b.Real
//         );
//     }

//     public override string ToString()
//     {
//         return $"{Real} + {Imag}i";
//     }
// }

// ComplexNumber c1 = new ComplexNumber(2, 3);
// ComplexNumber c2 = new ComplexNumber(1, 4);
// Console.WriteLine(c1 * c2);



// ========================== Q7 ==========================
// Modify Gender enum to use byte and check memory size

// enum Gender : byte
// {
//     Male = 1,
//     Female = 2
// }

// Console.WriteLine(sizeof(Gender));



// ========================== Q8 ==========================
// Static temperature conversion methods

// static class Utility2
// {
//     public static double CelsiusToFahrenheit(double c)
//     {
//         return (c * 9 / 5) + 32;
//     }

//     public static double FahrenheitToCelsius(double f)
//     {
//         return (f - 32) * 5 / 9;
//     }
// }

// Console.WriteLine(Utility2.CelsiusToFahrenheit(30));



// ========================== Q9 ==========================
// Parse string to Grades using TryParse

// string input = "A";
// if (Enum.TryParse(input, out Grades result))
// {
//     Console.WriteLine(result);
// }
// else
// {
//     Console.WriteLine("Invalid Grade");
// }



// ========================== Q10 ==========================
// Override Equals in Employee and search in array

// class Employee
// {
//     public int Id { get; set; }
//     public string Name { get; set; }

//     public override bool Equals(object obj)
//     {
//         if (obj is Employee other)
//             return Id == other.Id;
//         return false;
//     }
// }

// class Helper2<T>
// {
//     public static int SearchArray(T[] arr, T value)
//     {
//         for (int i = 0; i < arr.Length; i++)
//         {
//             if (arr[i].Equals(value))
//                 return i;
//         }
//         return -1;
//     }
// }



// ========================== Q11 ==========================
// Generic Max method

// class Helper
// {
//     public static T Max<T>(T a, T b) where T : IComparable
//     {
//         return a.CompareTo(b) > 0 ? a : b;
//     }
// }

// Console.WriteLine(Helper.Max(5, 10));
// Console.WriteLine(Helper.Max(3.5, 7.2));
// Console.WriteLine(Helper.Max("Ali", "Zara"));



// ========================== Q12 ==========================
// ReplaceArray method in generic class

// class Helper3<T>
// {
//     public static void ReplaceArray(T[] arr, T oldValue, T newValue)
//     {
//         for (int i = 0; i < arr.Length; i++)
//         {
//             if (arr[i].Equals(oldValue))
//                 arr[i] = newValue;
//         }
//     }
// }



// ========================== Q13 ==========================
// Non-generic swap for Rectangle struct

// struct Rectangle
// {
//     public double Length;
//     public double Width;
// }

// static void Swap(ref Rectangle r1, ref Rectangle r2)
// {
//     Rectangle temp = r1;
//     r1 = r2;
//     r2 = temp;
// }



// ========================== Q14 ==========================
// Department class and searching employees by department

// class Department
// {
//     public string Name { get; set; }

//     public override bool Equals(object obj)
//     {
//         if (obj is Department other)
//             return Name == other.Name;
//         return false;
//     }
// }



// ========================== Q15 ==========================
// Struct Circle vs Class Circle comparison

// struct Circle
// {
//     public double Radius;
//     public string Color;
// }

// class CircleClass
// {
//     public double Radius;
//     public string Color;
// }
