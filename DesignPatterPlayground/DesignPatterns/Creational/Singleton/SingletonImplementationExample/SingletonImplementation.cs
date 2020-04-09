using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesignPatterPlayground.DesignPatterns.Creational.Singleton.SingletonImplementationExample
{
    public static class SingletonImplementation
    {
        public static void Run()
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            var population = db.GetPopulation("Tokyo");
            Console.WriteLine($"{city}: {nameof(population)}: {population}");
        }
    }

    public interface IDatabase
    {
        int GetPopulation(string city);
    }

    public class SingletonDatabase : IDatabase
    {
        private IDictionary<string, int> capitals;
        private static SingletonDatabase instance = new SingletonDatabase();

        public static SingletonDatabase Instance => instance;

        private SingletonDatabase()
        {
            Console.WriteLine("Initializing database");

            // Stubbed out read from a 'database'.
            capitals = File.ReadAllLines(@"DesignPatterns\Creational\Singleton\SingletonImplementationExample\Capitals.txt")
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
