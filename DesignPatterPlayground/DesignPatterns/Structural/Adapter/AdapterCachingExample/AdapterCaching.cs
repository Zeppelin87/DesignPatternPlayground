using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesignPatterPlayground.DesignPatterns.Structural.Adapter.AdapterCachingExample
{
    public static class AdapterCaching
    {
        public static void Run()
        {
            var vectorObjects = new List<VectorObject>()
            {
                new VectorRectangle(1, 1, 10, 10),
                new VectorRectangle(3, 3, 6, 6)
            };

            Draw(vectorObjects);
            Draw(vectorObjects);
        }

        public static void Draw(List<VectorObject>vectorObjects)
        {
            foreach (var vectorObject in vectorObjects)
            {
                foreach (var line in vectorObject)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }

        public static void DrawPoint(Point point)
        {
            Console.Write(".");
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        protected bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }

    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }

        protected bool Equals(Line other)
        {
            return Equals(Start, other.Start) && Equals(End, other.End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Start != null ? Start.GetHashCode() : 0) * 397) ^ (End != null ? End.GetHashCode() : 0);
            }
        }
    }

    // A VectorObject is just a list of lines.
    public class VectorObject : Collection<Line>
    {

    }

    // A VectorRectange conatins 4 lines.
    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int count = 0;

        // The key to the cache is the hash of the line.
        private Dictionary<int, List<Point>> cache
            = new Dictionary<int, List<Point>>();

        public LineToPointAdapter(Line line)
        {
            // If the line has already been cached then don't process points.
            var hash = line.GetHashCode();
            if (cache.ContainsKey(hash))
            {
                return;
            }

            Console.WriteLine($"{++count}: Generating " +
                $"points for line [{line.Start.X}," +
                $"{line.Start.Y}]-[{line.End.X},{line.End.Y}]" +
                $" (no caching)");

            var points = new List<Point>();

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }
            }

            cache.Add(hash, points);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return cache.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
