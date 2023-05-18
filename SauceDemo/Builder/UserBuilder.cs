using System;
using Bogus;
using NUnit.Framework;
using SauceDemo.Models;

namespace SauceDemo.Builder
{
    public static class UserBuilder
    {
        static Faker Faker = new Faker();

        public static User StandartUser => new User
        {
            Name = TestContext.Parameters.Get("StandartUserName"),
            Password = TestContext.Parameters.Get("StarndartUserPassword"),
            FirstName = Faker.Internet.UserName(lastName:""),
            LastName = Faker.Internet.UserName(firstName:""),
            ZipPostalCode = Faker.Random.Int(5).ToString(),
        };

        public static User StandartUserWithIncorrectPassword => new User
        {
            Name = TestContext.Parameters.Get("StandartUserName"),
            Password = TestContext.Parameters.Get("IncorrectPassword"),
        };

        public static User GetRandomUser() => new()
        {
            Name = Faker.Internet.Email(provider: "QA_Test.13May"),
            Password = Faker.Internet.Password(12),
        };

        public static User GetRandomUser(string email) => new()
        {
            Name = email,
            Password = Faker.Internet.Password(13),
        };
    }
}