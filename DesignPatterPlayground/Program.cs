using DesignPatterPlayground.DesignPatterns.Creational.Builder;
using DesignPatterPlayground.SolidPrinciples;

namespace DesignPatterPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSOLIDPrinciples();
            RunCreationalPatterns();
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
