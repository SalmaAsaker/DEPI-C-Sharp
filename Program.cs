// using System;
// using System.Collections.Generic;
// using System.Linq;


// ========================== Q1 ==========================
// Implement generic sorting algorithm for Employee by Salary ascending

// class Employee : ICloneable
// {
//     public string Name { get; set; }
//     public double Salary { get; set; }

//     public object Clone()
//     {
//         return new Employee { Name = this.Name, Salary = this.Salary };
//     }

//     public override string ToString()
//     {
//         return $"{Name} - {Salary}";
//     }
// }

// class SortingAlgorithm<T> where T : ICloneable
// {
//     public static void Sort(T[] array, Func<T, T, bool> compare)
//     {
//         for (int i = 0; i < array.Length; i++)
//         {
//             for (int j = i + 1; j < array.Length; j++)
//             {
//                 if (!compare(array[i], array[j]))
//                 {
//                     Swap(ref array[i], ref array[j]);
//                 }
//             }
//         }
//     }

//     public static void Swap<U>(ref U a, ref U b)
//     {
//         U temp = a;
//         a = b;
//         b = temp;
//     }
// }


// ========================== Q2 ==========================
// SortingTwo<T> descending using lambda

// class SortingTwo<T>
// {
//     public static void Sort(T[] array, Comparison<T> comparer)
//     {
//         Array.Sort(array, comparer);
//     }
// }

// int[] numbers = { 5, 2, 9, 1 };
// SortingTwo<int>.Sort(numbers, (a, b) => b.CompareTo(a));


// ========================== Q3 ==========================
// Sort strings by length ascending

// string[] words = { "apple", "hi", "banana" };
// SortingTwo<string>.Sort(words, (a, b) => a.Length.CompareTo(b.Length));


// ========================== Q4 ==========================
// Manager class implementing IComparable

// class Manager : Employee, IComparable<Manager>
// {
//     public int CompareTo(Manager other)
//     {
//         return this.Salary.CompareTo(other.Salary);
//     }
// }


// ========================== Q5 ==========================
// Func delegate comparing Employee by Name length

// Employee[] employees =
// {
//     new Employee { Name = "Ali", Salary = 5000 },
//     new Employee { Name = "Mohamed", Salary = 4000 }
// };

// SortingAlgorithm<Employee>.Sort(employees,
//     (a, b) => a.Name.Length < b.Name.Length);


// ========================== Q6 ==========================
// Anonymous function vs Lambda sorting

// int[] arr = { 4, 1, 3 };

// Array.Sort(arr, delegate (int a, int b)
// {
//     return a.CompareTo(b);
// });

// Array.Sort(arr, (a, b) => a.CompareTo(b));


// ========================== Q7 ==========================
// Swap method demonstration

// int[] values = { 1, 2 };
// SortingAlgorithm<int>.Swap(ref values[0], ref values[1]);


// ========================== Q8 ==========================
// Multi-criteria sorting Salary then Name

// SortingTwo<Employee>.Sort(employees,
//     (a, b) =>
//     {
//         int salaryCompare = a.Salary.CompareTo(b.Salary);
//         if (salaryCompare == 0)
//             return a.Name.CompareTo(b.Name);
//         return salaryCompare;
//     });


// ========================== Q9 ==========================
// default(T) demonstration

// static T GetDefault<T>()
// {
//     return default(T);
// }

// int defaultInt = GetDefault<int>();
// Employee defaultEmployee = GetDefault<Employee>();


// ========================== Q10 ==========================
// Clone Employee array before sorting

// Employee[] original = employees;
// Employee[] cloned = original.Select(e => (Employee)e.Clone()).ToArray();


// ========================== Q11 ==========================
// Delegate string transformation

// delegate string StringTransformer(string input);

// List<string> TransformList(List<string> list, StringTransformer transformer)
// {
//     return list.Select(s => transformer(s)).ToList();
// }


// ========================== Q12 ==========================
// Delegate for mathematical operations

// delegate int MathOperation(int a, int b);

// int Calculate(int a, int b, MathOperation op)
// {
//     return op(a, b);
// }


// ========================== Q13 ==========================
// Generic delegate transformation

// delegate R Transformer<T, R>(T input);

// List<R> Transform<T, R>(List<T> list, Transformer<T, R> transformer)
// {
//     return list.Select(item => transformer(item)).ToList();
// }


// ========================== Q14 ==========================
// Func square example

// Func<int, int> square = x => x * x;

// List<int> squares = new List<int> { 1, 2, 3 }
//     .Select(square).ToList();


// ========================== Q15 ==========================
// Action example

// Action<string> printer = s => Console.WriteLine(s);

// void ApplyAction(List<string> list, Action<string> action)
// {
//     foreach (var item in list)
//         action(item);
// }


// ========================== Q16 ==========================
// Predicate even filter

// Predicate<int> isEven = x => x % 2 == 0;

// List<int> Filter(List<int> list, Predicate<int> predicate)
// {
//     return list.Where(x => predicate(x)).ToList();
// }


// ========================== Q17 ==========================
// Anonymous function filter strings

// List<string> FilterStrings(List<string> list, Func<string, bool> condition)
// {
//     return list.Where(s => condition(s)).ToList();
// }


// ========================== Q18 ==========================
// Anonymous math operation

// int Perform(int a, int b, Func<int, int, int> operation)
// {
//     return operation(a, b);
// }


// ========================== Q19 ==========================
// Lambda filter strings

// var filtered = FilterStrings(
//     new List<string> { "one", "three", "hello" },
//     s => s.Length > 3);


// ========================== Q20 ==========================
// Lambda math double

// double Operate(double a, double b, Func<double, double, double> op)
// {
//     return op(a, b);
// }