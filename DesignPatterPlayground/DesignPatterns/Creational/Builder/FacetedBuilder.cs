using System;

namespace DesignPatterPlayground.DesignPatterns.Creational.Builder
{
    public static class FacetedBuilder
    {
        public static void Run()
        {
            var builder = new UserBuilder();
            User user = builder
                .Works.At("Google").AsA("Engineer").Earning(50)
                .Lives.At("123 Usr Blvd").In("New York").WithPostalCode("55463");

            Console.WriteLine(user);
        }
    }

    public class User
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
            return $"{nameof(this.StreetAddress)}: {this.StreetAddress}," +
                $" {nameof(this.PostalCode)}: {this.PostalCode}, {nameof(this.City)}: {this.City}," +
                $"{nameof(this.CompanyName)}: {this.CompanyName}, {nameof(this.Position)}: {this.Position}," +
                $" {nameof(this.AnnualIncome)}: {this.AnnualIncome}";
        }
    }

    // This is a facade for the 2 other builders.
    public class UserBuilder
    {
        protected User user = new User();

        public UserJobBuilder Works => new UserJobBuilder(user);
        public UserAddressBuilder Lives => new UserAddressBuilder(user);

        // Implicit conversion operator.
        public static implicit operator User(UserBuilder builder)
        {
            return builder.user;
        }
    }

    public class UserJobBuilder : UserBuilder
    {
        public UserJobBuilder(User user)
        {
            base.user = user;
        }

        public UserJobBuilder At(string companyName)
        {
            user.CompanyName = companyName;
            return this;
        }

        public UserJobBuilder AsA(string position)
        {
            user.Position = position;
            return this;
        }

        public UserJobBuilder Earning(int annualIncome)
        {
            user.AnnualIncome = annualIncome;
            return this;
        }
    }

    public class UserAddressBuilder : UserBuilder
    {
        public UserAddressBuilder(User user)
        {
            base.user = user;
        }

        public UserAddressBuilder At(string streetAddress)
        {
            user.StreetAddress = streetAddress;
            return this;
        }

        public UserAddressBuilder WithPostalCode(string postalCode)
        {
            user.PostalCode = postalCode;
            return this;
        }

        public UserAddressBuilder In(string city)
        {
            user.City = city;
            return this;
        }
    }
}
