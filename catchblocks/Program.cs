using System;

class Program
{
    public static void Main(string[] args)
    {
        string input = "49"; // or use "49" in a notebook
        try
        {
            int age = int.Parse(input);
            Console.WriteLine($"You are {age} years old.");
        }
        catch (FormatException)
        {
            Console.WriteLine("The age you entered is not a valid number format");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.GetType()} says {ex.Message}");
        }
    }
}
