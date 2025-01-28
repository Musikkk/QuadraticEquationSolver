using System;

namespace QuadraticEquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter coefficient a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter coefficient b:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter coefficient c:");
            double c = Convert.ToDouble(Console.ReadLine());

            try
            {
                var result = QuadraticSolver.Solve(a, b, c);

                if (result.NumberOfRoots == 0)
                {
                    Console.WriteLine("No real roots.");
                }
                else if (result.NumberOfRoots == 1)
                {
                    Console.WriteLine($"One real root: {result.Root1}");
                }
                else
                {
                    Console.WriteLine($"Two real roots: {result.Root1} and {result.Root2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
