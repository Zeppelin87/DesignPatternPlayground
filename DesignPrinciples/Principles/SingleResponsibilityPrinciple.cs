using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesignPrinciples.Principles
{
    public static class SingleResponsibilityPrinciple
    {
        public static void Run()
        {
            var journal = new Journal();
            journal.AddEntry("I ate food.");
            journal.AddEntry("I went for a run.");
            Console.WriteLine(journal);

            var persistence = new Persistence();
            var filename = @"c:\temp\journal.txt";
            persistence.SaveToFile(journal, filename, true);
            Process.Start(filename);
        }
    }

    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, journal.ToString());
            }
        }

        public static Journal Load(string filename)
        {
            return new Journal();
        }
    }
}
