using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Builder
{
    public static class FacetedBuilder
    {
        public static void Run()
        {
            var builder = new DogBuilder();
            Dog dog = builder
                .Works.At("Google").AsA("Engineer").Earning(50)
                .Lives.At("123 Dog Blvd").In("Eden Prairie").WithPostalCode("55463");

            Console.WriteLine(dog);
        }
    }

    // Using 'Dog' because using 'Person' will cause naming collisions.
    // We make 2 builder facades
    // 1. A facade for building address information
    // 2. A facade for building employment information
    public class Dog
    {
        // address
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        // employment
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public int AnnualIncome { get; set; }

        public override string ToString()
        {
            return $"{nameof(this.StreetAddress)}: {this.StreetAddress}, {nameof(this.PostalCode)}: {this.PostalCode}, {nameof(this.City)}: {this.City}," +
                $"{nameof(this.CompanyName)}: {this.CompanyName}, {nameof(this.Position)}: {this.Position}, {nameof(this.AnnualIncome)}: {this.AnnualIncome}";
        }
    }

    // This is a facade - which doesn't build up 'Dog' directly.
    // Instead it acts as a facade for our other builders.
    public class DogBuilder
    {
        protected Dog Dog = new Dog();

        public DogJobBuilder Works => new DogJobBuilder(Dog);
        public DogAddressBuilder Lives => new DogAddressBuilder(Dog);

        // Implicit conversion operator.
        public static implicit operator Dog(DogBuilder builder)
        {
            return builder.Dog;
        }
    }

    // Builds employment information for a 'Dog' object.
    public class DogJobBuilder : DogBuilder
    {
        public DogJobBuilder(Dog dog)
        {
            Dog = dog;
        }

        public DogJobBuilder At(string companyName)
        {
            Dog.CompanyName = companyName;
            return this;
        }

        public DogJobBuilder AsA(string position)
        {
            Dog.Position = position;
            return this;
        }

        public DogJobBuilder Earning(int annualIncome)
        {
            Dog.AnnualIncome = annualIncome;
            return this;
        }
    }

    public class DogAddressBuilder : DogBuilder
    {
        public DogAddressBuilder(Dog dog)
        {
            Dog = dog;
        }

        public DogAddressBuilder At(string streetAddress)
        {
            Dog.StreetAddress = streetAddress;
            return this;
        }

        public DogAddressBuilder WithPostalCode(string postalCode)
        {
            Dog.PostalCode = postalCode;
            return this;
        }

        public DogAddressBuilder In(string city)
        {
            Dog.City = city;
            return this;
        }
    }
}
