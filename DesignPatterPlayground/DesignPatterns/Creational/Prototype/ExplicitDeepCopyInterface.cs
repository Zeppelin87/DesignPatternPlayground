using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Prototype
{
    public static class ExplicitDeepCopyInterface
    {
        public static void Run()
        {
            var address = new Address2("Colorado Springs", "CO");
            var rick = new User2("Rick", "Kinch", address);
            Console.WriteLine(rick);

            // Use the `DeepCopy()` function found on `User`
            var john = rick.DeepCopy();
            Console.WriteLine(john);
            Console.WriteLine();

            john.FirstName = "John";
            john.LastName = "ChickenHawk";
            john.Address.City = "Purchamous";
            john.Address.State = "MN";

            Console.WriteLine(john); // john.FirstName = "John"...
            Console.WriteLine(rick); // rick.FirstName = "Rick"...
        }
    }

    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class User2 : IPrototype<User2>
    {
        public User2() { }

        public User2(string firstName, string lastName, Address2 address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address2 Address { get; set; }

        public override string ToString()
        {
            return $"User -> {nameof(FirstName)}: {FirstName}," +
                $" {nameof(LastName)}: {LastName}," +
                $" {nameof(Address)}: {Address.ToString()}";
        }

        public User2 DeepCopy()
        {
            return new User2(FirstName, LastName, Address.DeepCopy());
        }
    }

    public class Address2 : IPrototype<Address2>
    {
        public Address2() { }

        public Address2(string city, string state)
        {
            City = city;
            State = state;
        }

        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"{nameof(City)}: {City}, {nameof(State)}: {State}";
        }

        public Address2 DeepCopy()
        {
            return new Address2(City, State);
        }
    }
}
