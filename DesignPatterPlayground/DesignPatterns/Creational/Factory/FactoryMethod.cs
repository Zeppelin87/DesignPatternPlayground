using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Factory
{
    public static class FactoryMethod
    {
        public static void Run()
        {
            var polarPoint = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(polarPoint); // output -> x: 6.12303176911189E-17, y: 1

            var cartesianPoint = Point.NewCartesianPoint(1, 2);
            Console.WriteLine(cartesianPoint); // output ->  x: 1, y: 2
        }
    }

    public class Point
    {
        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        // factory method
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private double X, Y;

        private Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
