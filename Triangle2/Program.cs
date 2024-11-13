using System;

namespace TriangleApp
{
    public enum TriangleType
    {
        Equilateral, 
        Isosceles,   
        Scalene,      
        NotTriangle   
    }

    public class Triangle
    {
        public static TriangleType DetermineTriangleType(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
                return TriangleType.NotTriangle;

            if (a == b && b == c)
                return TriangleType.Equilateral;
            else if (a == b || b == c || a == c)
                return TriangleType.Isosceles;
            else
                return TriangleType.Scalene;
        }

        public static bool IsValidTriangle(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0 &&
                   a + b > c &&
                   a + c > b &&
                   b + c > a;
        }

        public static double CalculateArea(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
                throw new ArgumentException("The provided sides do not form a triangle.");

            double semiPerimeter = (a + b + c) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину стороны a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите длину стороны b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите длину стороны c: ");
            double c = double.Parse(Console.ReadLine());

            if (!Triangle.IsValidTriangle(a, b, c))
            {
                Console.WriteLine("Введенные значения не образуют треугольник.");
            }
            else
            {
                var type = Triangle.DetermineTriangleType(a, b, c);
                Console.WriteLine($"Тип треугольника: {type}");

                double area = Triangle.CalculateArea(a, b, c);
                Console.WriteLine($"Площадь треугольника: {area}");
            }
        }
    }
}
