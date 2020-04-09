using DesignPatterPlayground.DesignPatterns.Creational.Builder;
using DesignPatterPlayground.DesignPatterns.Creational.Factory;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.AbstractFactoryExample;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.FactoryExample;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.InnerFactoryExample;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype.CopyConstructorsExample;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype.CopyThroughSerializationExample;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype.ExplicitDeepCopyInterfaceExample;
using DesignPatterPlayground.DesignPatterns.Creational.Singleton.SingletonImplementationExample;
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
            // 1. Builder Design Patterns
            //Builder.Run();
            //FluentBuilderInheritance.Run();
            //FunctionalBuilder.Run();
            //FacetedBuilder.Run();

            // 2. Factory Design Patterns
            //FactoryMethod.Run();
            //Factory.Run();
            //InnerFactory.Run();
            //AbstractFactory.Run();

            // 3. Prototype Design Patterns
            //ICloneableIsBad.Run();
            //CopyConstructors.Run();
            //ExplicitDeepCopyInterface.Run();
            //CopyThroughSerialization.Run();

            // 4. Singleton Design Patterns
            SingletonImplementation.Run();
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
