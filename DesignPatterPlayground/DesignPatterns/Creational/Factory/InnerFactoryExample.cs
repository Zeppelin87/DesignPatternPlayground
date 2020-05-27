using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Factory
{
    public static class InnerFactoryExample
    {
        public static void Run()
        {
            var polarPoint = Point1.Factory1.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(polarPoint); // output -> x: 6.12303176911189E-17, y: 1

            var cartesianPoint = Point1.Factory1.NewCartesianPoint(1, 2);
            Console.WriteLine(cartesianPoint); // output ->  x: 1, y: 2
        }
    }

    public class Point1
    {
        private double X, Y;

        private Point1(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        public static class Factory1
        {
            public static Point1 NewCartesianPoint(double x, double y)
            {
                return new Point1(x, y);
            }

            public static Point1 NewPolarPoint(double rho, double theta)
            {
                return new Point1(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
}
