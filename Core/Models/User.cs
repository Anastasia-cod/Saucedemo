using System;
using Core.Models.Enums;

namespace Core.Models
{
    public class User
    {
        public UserType UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipPostalCode { get; set; }
    }
}

