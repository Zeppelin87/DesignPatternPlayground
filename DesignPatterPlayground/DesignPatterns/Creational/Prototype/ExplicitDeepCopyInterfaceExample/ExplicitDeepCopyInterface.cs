using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Prototype.ExplicitDeepCopyInterfaceExample
{
    public static class ExplicitDeepCopyInterface
    {
        public static void Run()
        {
            var address = new Address("Colorado Springs", "CO");
            var rick = new User("Rick", "Kinch", address);
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

    public class User : IPrototype<User>
    {
        public User() { }

        public User(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            return $"User -> {nameof(FirstName)}: {FirstName}," +
                $" {nameof(LastName)}: {LastName}," +
                $" {nameof(Address)}: {Address.ToString()}";
        }

        public User DeepCopy()
        {
            return new User(FirstName, LastName, Address.DeepCopy());
        }
    }

    public class Address : IPrototype<Address>
    {
        public Address() { }

        public Address(string city, string state)
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

        public Address DeepCopy()
        {
            return new Address(City, State);
        }
    }
}
