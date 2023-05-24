using System;
using Bogus;
using NUnit.Framework;
using Core.Models;

namespace Core.Models.Builder
{
    public class UserBuilder
    {
        private User user;

        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetName(string name)
        {
            user.UserName = name;
            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            user.Password = password;
            return this;
        }

        public UserBuilder SetFirstName(string firstName)
        {
            user.FirstName = firstName;
            return this;
        }

        public UserBuilder SetLastName(string lastName)
        {
            user.LastName = lastName;
            return this;
        }

        public UserBuilder SetZipOrPostalCode(string zipOrPostalCode)
        {
            user.ZipPostalCode = zipOrPostalCode;
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}