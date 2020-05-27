using Newtonsoft.Json;
using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Prototype
{
    public static class CopyThroughSerialization
    {
        public static void Run()
        {
            var address = new Address1("Colorado Springs", "CO");
            var rick = new User1("Rick", "Kinch", address);
            Console.WriteLine(rick);

            // Use the `DeepCopy()` function found on `User`
            var john = ExtensionMethods1.DeepCopy(rick);
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

    public static class ExtensionMethods1
    {
        public static T DeepCopy<T>(T self)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(self));
        }
    }

    public class User1
    {
        public User1() { }

        public User1(string firstName, string lastName, Address1 address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address1 Address { get; set; }

        public override string ToString()
        {
            return $"User -> {nameof(FirstName)}: {FirstName}," +
                $" {nameof(LastName)}: {LastName}," +
                $" {nameof(Address)}: {Address.ToString()}";
        }
    }

    public class Address1
    {
        public Address1() { }

        public Address1(string city, string state)
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
