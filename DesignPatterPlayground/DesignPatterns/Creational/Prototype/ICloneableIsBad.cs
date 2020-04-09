using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Prototype
{
    public static class ICloneableIsBad
    {
        public static void Run()
        {
            var address = new Address("Colorado Springs", "CO");
            var rick = new User("Rickity", "Kinch", address);

            Console.WriteLine(rick.FirstName); // Rick

            var jane = rick;
            Console.WriteLine(jane.FirstName); // Rick

            jane.FirstName = "Jane";
            Console.WriteLine(jane.FirstName); // Jane
            Console.WriteLine(rick.FirstName); // Jane

            Console.WriteLine();
            
            //
            // Remove the `: ICloneable` from `Address` for this example to work.
            //
            
            //var address1 = new Address("Ricky", "Ticky-Tumbo");
            //var kraw = new User("Kraw", "Dad-Le-Coost", address1);
            //Console.WriteLine(kraw.Address.State); // Ticky-Tumbo

            //var john = (User)kraw.Clone();
            
            //// user.FirstName & user.LastName are deep copied.
            //Console.WriteLine($"{kraw.FirstName} {kraw.LastName}"); // Kraw Dad-Le-Coost
            //Console.WriteLine($"{john.FirstName} {john.LastName}"); // Kraw Dad-Le-Coost

            //john.FirstName = "John";
            //john.LastName = "Howyadoin";
            //Console.WriteLine($"{kraw.FirstName} {kraw.LastName}"); // Kraw Dad-Le-Coost
            //Console.WriteLine($"{john.FirstName} {john.LastName}"); // John Howyadoin

            //Console.WriteLine();

            //// `user.Address` is shallow copied.
            //Console.WriteLine(john.Address.State); // Ticky-Tumbo

            //john.Address.State = "MN";
            //Console.WriteLine(john.Address.State); // MN
            //Console.WriteLine(kraw.Address.State); // MN

            //Console.WriteLine();
        }
    }

    public class User : ICloneable
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

        // Deep copy of all `User` properties.
        public object Clone()
        {
            return new User(FirstName, LastName, (Address)Address.Clone());
        }
    }

    public class Address : ICloneable
    {
        public Address() { }

        public Address(string city, string state)
        {
            City = city;
            State = state;
        }

        public string City { get; set; }
        public string State { get; set; }

        // Generates a deep clone of the `Address` object.
        public object Clone()
        {
            return new Address(City, State);
        }
    }
}
