using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace LargestNumberFinder
{
    public class NumberProgram
    {
        static void Main(string[] args)
        {
            int largest = 0;
            for (int i = 0; i < 10; i++)
            {
                ProcessInput(Console.ReadLine(), ref largest);
            }

        }

        public static int ProcessInput(string input, ref int largest)
        {
            Console.Write("Please enter a number");
            input = Console.ReadLine();
            int number = Convert.ToInt32(input);
            
            if (number > largest)
            {
                largest = number;
            }
        }
    }
}
