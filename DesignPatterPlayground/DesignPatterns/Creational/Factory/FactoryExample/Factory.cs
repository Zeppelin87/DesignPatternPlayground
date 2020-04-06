using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Factory.FactoryExample
{
    public static class Factory
    {
        public static void Run()
        {
            var polarPoint = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(polarPoint); // output -> x: 6.12303176911189E-17, y: 1

            var cartesianPoint = PointFactory.NewCartesianPoint(1, 2);
            Console.WriteLine(cartesianPoint); // output ->  x: 1, y: 2
        }

        public static class PointFactory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

        public class Point
        {
            private double X, Y;

            public Point(double x, double y)
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
}
