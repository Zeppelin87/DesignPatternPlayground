using System;
using System.Diagnostics;

namespace DesignPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleResponsibilityPrinciple();
        }

        private static void SingleResponsibilityPrinciple()
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
}
