using DesignPatterPlayground.DesignPatterns.Creational.Builder;
using DesignPatterPlayground.DesignPatterns.Creational.Factory;
using DesignPatterPlayground.SolidPrinciples;

namespace DesignPatterPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            //SOLIDPrinciples();
            CreationalPatterns();
        }

        private static void CreationalPatterns()
        {
            //BuilderPatterns();
            FactoryExamples();
        }

        #region S.O.I.L.D. Principles

        private static void SOLIDPrinciples()
        {
            SingleResponsibilityPrinciple.Run();
            OpenClosedPrinciple.Run();
            LiskovSubstitutionPrinciple.Run();
            InterfaceSegregationPrinciple.Run();
            DependecyInversionPrinciple.Run();
        }

        #endregion

        #region Creational Builders

        private static void BuilderPatterns()
        {
            Builder.Run();
            FluentBuilderInheritance.Run();
            FunctionalBuilder.Run();
            FacetedBuilder.Run();
        }

        private static void FactoryExamples()
        {
            PointerExample.Run();
        }

        #endregion
    }
}
