using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Prototype.CopyConstructorsExample
{
    public static class CopyConstructors
    {
        public static void Run()
        {
            var address = new Address("Colorado Springs", "CO");
            var rick = new User("Rick", "Kinch", address);
            Console.WriteLine(rick);

            // Copy constructor called on object instantiation.
            var john = new User(rick);
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

    public class User
    {
        public User() { }

        public User(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public User(User other)
        {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Address = new Address(other.Address);
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
    }

    public class Address
    {
        public Address() { }

        public Address(string city, string state)
        {
            City = city;
            State = state;
        }

        public Address(Address other)
        {
            City = other.City;
            State = other.State;
        }

        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"{nameof(City)}: {City}, {nameof(State)}: {State}";
        }
    }
}

