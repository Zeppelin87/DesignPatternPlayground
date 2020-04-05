using System;

namespace DesignPatterPlayground.SOLID_Design_Principles
{
    // Average example - look elsewhere...
    public static class LiskovSubstitutionPrinciple
    {
        public static int Area(Rectangle rectangle) => rectangle.Width * rectangle.Height;

        public static void Run()
        {
            var retangle = new Rectangle(2, 3);
            Console.WriteLine($"{retangle} , Area: {Area(retangle)}");

            var square = new Square();
            square.Width = 4;
            Console.WriteLine($"{square} , Area: {Area(square)}");
        }
    }

    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle() { }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set
            {
                base.Width = base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Height = base.Width = value;
            }
        }
    }
}
