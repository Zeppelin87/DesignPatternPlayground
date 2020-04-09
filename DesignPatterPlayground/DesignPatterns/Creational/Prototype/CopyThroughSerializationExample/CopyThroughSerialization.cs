using Newtonsoft.Json;
using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Prototype.CopyThroughSerializationExample
{
    public static class CopyThroughSerialization
    {
        public static void Run()
        {
            var address = new Address("Colorado Springs", "CO");
            var rick = new User("Rick", "Kinch", address);
            Console.WriteLine(rick);

            // Use the `DeepCopy()` function found on `User`
            var john = ExtensionMethods.DeepCopy(rick);
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

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(T self)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(self));
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

        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"{nameof(City)}: {City}, {nameof(State)}: {State}";
        }
    }
}
