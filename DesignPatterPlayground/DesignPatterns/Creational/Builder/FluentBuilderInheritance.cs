using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Builder
{
    // With Recursive Generics
    public static class FluentBuilderInheritance
    {
        public static void Run()
        {
            var person = Person.New
                .Called("dimitri")
                .WorkAsA("quant")
                .Build();

            Console.WriteLine(person);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(this.Name)}: {this.Name}, {nameof(this.Position)}: {this.Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person Person = new Person();

        public Person Build()
        {
            return Person;
        }
    }

    public class PersonInfoBuilder<T> : PersonBuilder where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            this.Person.Name = name;
            return (T)this;
        }
    }

    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>> where T : PersonJobBuilder<T>
    {
        public T WorkAsA(string position)
        {
            this.Person.Position = position;
            return (T)this;
        }
    }
}
