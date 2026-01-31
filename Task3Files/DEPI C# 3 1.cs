using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string InputString = Console.ReadLine();

        // Using int.Parse
        try
        {
            int ParsedValue = int.Parse(InputString);
            Console.WriteLine("Result using int.Parse: " + ParsedValue);
        }
        catch (Exception ExceptionObject)
        {
            Console.WriteLine("int.Parse Error: " + ExceptionObject.Message);
        }

        // Using Convert.ToInt32
        try
        {
            int ConvertedValue = Convert.ToInt32(InputString);
            Console.WriteLine("Result using Convert.ToInt32: " + ConvertedValue);
        }
        catch (Exception ExceptionObject)
        {
            Console.WriteLine("Convert.ToInt32 Error: " + ExceptionObject.Message);
        }
    }
}

/*
Difference between int.Parse and Convert.ToInt32:
- int.Parse
Converts a string to an integer
Gives an error if the value is null or not a number

- Convert.ToInt32
Converts a value to an integer
Returns 0 if the value is null
Gives an error if the value is not a number
*/
