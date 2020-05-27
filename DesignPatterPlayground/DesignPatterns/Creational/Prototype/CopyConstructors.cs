using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Prototype
{
    public static class CopyConstructors
    {
        public static void Run()
        {
            var address = new Address3("Colorado Springs", "CO");
            var rick = new User3("Rick", "Kinch", address);
            Console.WriteLine(rick);

            // Copy constructor called on object instantiation.
            var john = new User3(rick);
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

    public class User3
    {
        public User3() { }

        public User3(string firstName, string lastName, Address3 address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public User3(User3 other)
        {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Address = new Address3(other.Address);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address3 Address { get; set; }

        public override string ToString()
        {
            return $"User -> {nameof(FirstName)}: {FirstName}," +
                $" {nameof(LastName)}: {LastName}," +
                $" {nameof(Address)}: {Address.ToString()}";
        }
    }

    public class Address3
    {
        public Address3() { }

        public Address3(string city, string state)
        {
            City = city;
            State = state;
        }

        public Address3(Address3 other)
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
