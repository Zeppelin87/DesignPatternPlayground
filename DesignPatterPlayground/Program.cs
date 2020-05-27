using DesignPatterPlayground.DesignPatterns.Behavioral.ChainOfResponsibility;
using DesignPatterPlayground.DesignPatterns.Behavioral.State;
using DesignPatterPlayground.DesignPatterns.Behavioral.StrategyPattern;
using DesignPatterPlayground.DesignPatterns.Behavioral.TemplateMethod;
using DesignPatterPlayground.DesignPatterns.Creational.Builder;
using DesignPatterPlayground.DesignPatterns.Creational.Factory;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype;
using DesignPatterPlayground.DesignPatterns.Creational.Singleton;
using DesignPatterPlayground.DesignPatterns.Structural.Adapter;
using DesignPatterPlayground.SolidPrinciples;

namespace DesignPatterPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            // Desing Principles
            SOLIDPrinciples();

            // Design Patterns 
            Creational();
            Structural();
            Behavioral();
        }

        #region Creational

        private static void Creational()
        {
            // 1.Builder. 
            Builder.Run();
            FluentBuilderInheritance.Run();
            FunctionalBuilder.Run();
            FacetedBuilder.Run();

            // 2.Factory. 
            FactoryMethod.Run();
            FactoryExample.Run();
            InnerFactoryExample.Run();
            AbstractFactory.Run();

            // 3.Prototype. 
            ICloneableIsBad.Run();
            CopyConstructors.Run();
            ExplicitDeepCopyInterface.Run();
            CopyThroughSerialization.Run();

            // 4.Singleton. 
            SingletonImplementation.Run();
            TestabilityIssues.Run();
            SingletonDependencyInjection.Run();
        }

        #endregion

        #region Structural

        private static void Structural()
        {
            // 1. Adapter.
            VectorRasterDemo.Run();
            AdapterCaching.Run();
            GenericValueAdapter.Run();
        }

        #endregion

        #region Behavioral

        private static void Behavioral()
        {
            // 1. Chain of Responsibility.
            MethodChain.Run();
            BrokerChain.Run();

            // 2. StrategyPattern.
            DynamicStrategy.Run();
            StaticStrategy.Run();
            EqualityAndComparisonStrategies.Run();

            // 3. Template Method.
            TemplateMethodExample.Run();
            FunctionalTemplateMethod.Run();

            // 4. State
            ClassicImplementation.Run();
        }

        #endregion

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
