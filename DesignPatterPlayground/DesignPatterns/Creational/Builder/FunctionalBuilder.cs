using System;
using System.Collections.Generic;

namespace DesignPatterPlayground.DesignPatterns.Creational.Builder
{
    public static class FunctionalBuilder
    {
        public static void Run()
        {
            var builder = new PerzonBuilder();
            var person = builder
                .Called("dimitri")
                .WorksAsA("dev")
                .Build();
            Console.WriteLine(person);
        }
    }

    // Person spelled as Perzon due to naming collisons.
    public class Perzon 
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"{nameof(this.Name)}: {this.Name}, {nameof(this.Position)}: {this.Position}";
        }
    }

    public class PerzonBuilder
    {
        // List of actions to take on the person while they are being built.
        public readonly List<Action<Perzon>> Actions = new List<Action<Perzon>>();

        public PerzonBuilder Called(string name)
        {
            Actions.Add(p => { p.Name = name; });
            return this;
        }

        public Perzon Build()
        {
            var p = new Perzon();
            Actions.ForEach(action => action(p));
            return p;
        }
    }

    public static class PersonBuilderExtensions
    {
        public static PerzonBuilder WorksAsA(this PerzonBuilder builder, string position)
        {
            builder.Actions.Add(p => { p.Position = position; });
            return builder;
        }
    }
}
