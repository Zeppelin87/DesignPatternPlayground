﻿using DesignPatterPlayground.DesignPatterns.Creational.Builder;
using DesignPatterPlayground.DesignPatterns.Creational.Factory;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.AbstractFactoryExample;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.FactoryExample;
using DesignPatterPlayground.DesignPatterns.Creational.Factory.InnerFactoryExample;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype.CopyConstructorsExample;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype.CopyThroughSerializationExample;
using DesignPatterPlayground.DesignPatterns.Creational.Prototype.ExplicitDeepCopyInterfaceExample;
using DesignPatterPlayground.DesignPatterns.Creational.Singleton.SingletonDependencyInjectionExample;
using DesignPatterPlayground.DesignPatterns.Creational.Singleton.SingletonImplementationExample;
using DesignPatterPlayground.DesignPatterns.Creational.Singleton.TestabilityIssuesExample;
using DesignPatterPlayground.DesignPatterns.Structural.Adapter.VectorRasterExample;
using DesignPatterPlayground.SolidPrinciples;

namespace DesignPatterPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            //SOLIDPrinciples();
            //Creational();
            Structural();
        }

        #region Creational

        private static void Creational()
        {
            // 1.Builder 
            Builder.Run();
            FluentBuilderInheritance.Run();
            FunctionalBuilder.Run();
            FacetedBuilder.Run();

            // 2.Factory 
            FactoryMethod.Run();
            Factory.Run();
            InnerFactory.Run();
            AbstractFactory.Run();

            // 3.Prototype 
            ICloneableIsBad.Run();
            CopyConstructors.Run();
            ExplicitDeepCopyInterface.Run();
            CopyThroughSerialization.Run();

            // 4.Singleton 
            SingletonImplementation.Run();
            TestabilityIssues.Run();
            SingletonDependencyInjection.Run();
        }

        #endregion

        #region Structural

        private static void Structural()
        {
            // 1. Adapter
            VectorRasterDemo.Run();
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
