using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesignPatterPlayground.DesignPatterns.Structural.Adapter
{
    public static class AdapterCaching
    {
        public static void Run()
        {
            var vectorObjects = new List<VectorObject1>()
            {
                new VectorRectangle1(1, 1, 10, 10),
                new VectorRectangle1(3, 3, 6, 6)
            };

            Draw(vectorObjects);
            Draw(vectorObjects);
        }

        public static void Draw(List<VectorObject1> vectorObjects)
        {
            foreach (var vectorObject in vectorObjects)
            {
                foreach (var line in vectorObject)
                {
                    var adapter = new LineToPointAdapter1(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }

        public static void DrawPoint(Point1 point)
        {
            Console.Write(".");
        }
    }

    public class Point1
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point1(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        protected bool Equals(Point1 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point1)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }

    public class Line1
    {
        public Point1 Start { get; set; }
        public Point1 End { get; set; }

        public Line1(Point1 start, Point1 end)
        {
            this.Start = start;
            this.End = end;
        }

        protected bool Equals(Line1 other)
        {
            return Equals(Start, other.Start) && Equals(End, other.End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line1)obj);
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
    public class VectorObject1 : Collection<Line1>
    {

    }

    // A VectorRectange conatins 4 lines.
    public class VectorRectangle1 : VectorObject1
    {
        public VectorRectangle1(int x, int y, int width, int height)
        {
            Add(new Line1(new Point1(x, y), new Point1(x + width, y)));
            Add(new Line1(new Point1(x + width, y), new Point1(x + width, y + height)));
            Add(new Line1(new Point1(x, y), new Point1(x, y + height)));
            Add(new Line1(new Point1(x, y + height), new Point1(x + width, y + height)));
        }
    }

    public class LineToPointAdapter1 : IEnumerable<Point1>
    {
        private static int count = 0;

        // The key to the cache is the hash of the line.
        private Dictionary<int, List<Point1>> cache
            = new Dictionary<int, List<Point1>>();

        public LineToPointAdapter1(Line1 line)
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

            var points = new List<Point1>();

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
                    points.Add(new Point1(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point1(x, top));
                }
            }

            cache.Add(hash, points);
        }

        public IEnumerator<Point1> GetEnumerator()
        {
            return cache.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
