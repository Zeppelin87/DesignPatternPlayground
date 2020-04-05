using DesignPatterPlayground.DesignPatterns.Creational;
using DesignPatterPlayground.SolidPrinciples;
using System;
using System.Text;

namespace DesignPatterPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunSOLIDPrinciples();
            //RunCreationalPatterns();
            Testing(0);
            Testing(1);
            Testing(2);
        }

        static void Testing(int indent)
        {
            const int indentSize = 2;

            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            Console.WriteLine($"{i}Hello World");
        }

        private static void RunSOLIDPrinciples()
        {
            SingleResponsibilityPrinciple.Run();
            OpenClosedPrinciple.Run();
            LiskovSubstitutionPrinciple.Run();
            InterfaceSegregationPrinciple.Run();
            DependecyInversionPrinciple.Run();
        }

        private static void RunCreationalPatterns()
        {
            BuilderPattern.Run();
        }
    }
}
