using System;

namespace Tehnotronik.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public User(Guid id, string email, string username, string password, string name, string lastname, 
            string address, string city, string country, string phoneNumber, DateTime dateOfBirth)
        {
            Id = id;
            Email = email;
            Username = username;
            Password = password;
            Name = name;
            Lastname = lastname;
            Address = address;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }
    }
}
