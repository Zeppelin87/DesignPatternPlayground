﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesignPatterPlayground.DesignPatterns.Creational.Singleton
{
    public static class TestabilityIssues
    {
        public static void Run()
        {
            var db = SingletonDatabase2.Instance;
            var city = "Tokyo";
            var population = db.GetPopulation("Tokyo");
            Console.WriteLine($"{city}: {nameof(population)}: {population}");
        }
    }

    public interface IDatabase2
    {
        int GetPopulation(string city);
    }

    public class SingletonDatabase2 : IDatabase2
    {
        private IDictionary<string, int> capitals;

        private static int instanceCount; // 0 by default.
        public static int Count => instanceCount;

        private static SingletonDatabase2 instance = new SingletonDatabase2();
        public static SingletonDatabase2 Instance => instance;

        private SingletonDatabase2()
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

    public class SingletonRecordFinder2
    {
        public int GetTotalPopulation(IEnumerable<string> cities)
        {
            int result = 0;
            foreach (var city in cities)
            {
                result += SingletonDatabase2.Instance.GetPopulation(city);
            }

            return result;
        }
    }

    [TestClass]
    public class SingletonTests2
    {
        [TestMethod]
        public void IsSingleton()
        {
            var db = SingletonDatabase2.Instance;
            var db2 = SingletonDatabase2.Instance;

            // Tests that only one instance of `SingletonDatabase` is instantiated.
            Assert.AreEqual(db, db2);

            // Tests that the `SingletonDatabase` constructor is only called 1 time. 
            Assert.AreEqual(1, SingletonDatabase2.Count);
        }

        [TestMethod]
        public void SingletonTotalPopulationTest()
        {
            var recordFinder = new SingletonRecordFinder2();
            var cities = new List<string>() { "Seoul", "Mexico City" };
            int totalPopulation = recordFinder.GetTotalPopulation(cities);

            Assert.AreEqual(17500000 + 17400000, totalPopulation);
        }
    }
}
