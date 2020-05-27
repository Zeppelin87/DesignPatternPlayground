using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesignPatterPlayground.DesignPatterns.Creational.Singleton
{
    public static class SingletonImplementation
    {
        public static void Run()
        {
            var db = SingletonDatabase1.Instance;
            var city = "Tokyo";
            var population = db.GetPopulation("Tokyo");
            Console.WriteLine($"{city}: {nameof(population)}: {population}");
        }
    }

    public interface IDatabase1
    {
        int GetPopulation(string city);
    }

    public class SingletonDatabase1 : IDatabase1
    {
        private IDictionary<string, int> capitals;
        private static SingletonDatabase1 instance = new SingletonDatabase1();

        public static SingletonDatabase1 Instance => instance;

        private SingletonDatabase1()
        {
            Console.WriteLine("Initializing database");

            // Stubbed out read from a 'database'.
            capitals = File.ReadAllLines(@"DesignPatterns\Creational\Singleton\Capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string city)
        {
            return capitals[city];
        }
    }
}
