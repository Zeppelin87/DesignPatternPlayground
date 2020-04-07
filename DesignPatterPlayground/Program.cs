using DesignPatterPlayground.DesignPatterns.Creational.Builder;
using DesignPatterPlayground.DesignPatterns.Creational.Factory;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.AbstractFactoryExample;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.FactoryExample;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.InnerFactoryExample;
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
            // 1. Builder Patterns
            //Builder.Run();
            //FluentBuilderInheritance.Run();
            //FunctionalBuilder.Run();
            //FacetedBuilder.Run();

            // 2. Factory Patterns
            //FactoryMethod.Run();
            //Factory.Run();
            //InnerFactory.Run();
            AbstractFactory.Run();
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
    }
}
