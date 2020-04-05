using System;
using System.Collections.Generic;

namespace DesignPatterPlayground.SOLID_Design_Principles
{
    public static class OpenClosedPrinciple
    {
        public static void Run()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            ProductFilter productFilter = new ProductFilter();
            Console.WriteLine("Green products (old):");

            foreach (var product in productFilter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {product.Name} is green.");
            }

            var betterFilter = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach (var product in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {product.Name} is green.");
            }

            Console.WriteLine("Large blue products:");
            foreach (var product in betterFilter.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
            {
                Console.WriteLine($" - {product.Name} is large & blue.");
            }
        }
    }

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color Color { get; }

        public ColorSpecification(Color color)
        {
            Color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == Color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size Size { get; }

        public SizeSpecification(Size size)
        {
            Size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == Size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        ISpecification<T> First, Second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            First = first ?? throw new ArgumentNullException(paramName: nameof(first));
            Second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return First.IsSatisfied(t) && Second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var item in items)
            {
                if (specification.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }

    // Old way to filer
    // This breaks Open-Closed Principle
    // This is because we pretend we implemented FilterBySize() & FilterByColor() - then shipped the application
    // Later we came in and added FilterBySizeAndColor() - which breaks open-closed because we came back in a modified the class
    // Instead we should add functionality via inheritance - which we did by making the generic interfaces (see BetterFiler.cs...)
    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
            {
                if (product.Size == size)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
            {
                if (product.Color == color)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var product in products)
            {
                if (product.Size == size && product.Color == color)
                {
                    yield return product;
                }
            }
        }
    }
}
