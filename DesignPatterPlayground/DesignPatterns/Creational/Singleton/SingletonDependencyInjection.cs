using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesignPatterPlayground.DesignPatterns.Creational.Singleton
{
    public static class SingletonDependencyInjection
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

    public class ConfigurableRecordFinder
    {
        IDatabase _database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            _database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> cities)
        {
            int result = 0;
            foreach (var city in cities)
            {
                result += _database.GetPopulation(city);
            }

            return result;
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string city)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[city];
        }
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> cities)
        {
            int result = 0;
            foreach (var city in cities)
            {
                result += SingletonDatabase.Instance.GetPopulation(city);
            }

            return result;
        }
    }

    public class SingletonDatabase : IDatabase
    {
        private IDictionary<string, int> capitals;

        private static int instanceCount; // 0 by default.
        public static int Count => instanceCount;

        private static SingletonDatabase instance = new SingletonDatabase();
        public static SingletonDatabase Instance => instance;

        private SingletonDatabase()
        {
            instanceCount++;
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

    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void IsSingleton()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;

            // Tests that only one instance of `SingletonDatabase` is instantiated.
            Assert.AreEqual(db, db2);

            // Tests that the `SingletonDatabase` constructor is only called 1 time. 
            Assert.AreEqual(1, SingletonDatabase.Count);
        }

        [TestMethod]
        public void SingletonTotalPopulationTest()
        {
            var recordFinder = new SingletonRecordFinder();
            var cities = new List<string>() { "Seoul", "Mexico City" };
            int totalPopulation = recordFinder.GetTotalPopulation(cities);

            Assert.AreEqual(17500000 + 17400000, totalPopulation);
        }

        [TestMethod]
        public void ConfigurablePopulationTest()
        {
            var recordFinder = new ConfigurableRecordFinder(new DummyDatabase());
            var cities = new[] { "alpha", "gamma" };
            var totalPopulation = recordFinder.GetTotalPopulation(cities);

            Assert.AreEqual(4, totalPopulation);
        }
    }
}
