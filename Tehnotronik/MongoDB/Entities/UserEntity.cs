using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.MongoDB.Entities
{
    public class UserEntity : BaseEntity
    {
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
        public User ToUser()
            => new User(this.Id, this.Email, this.Username, this.Password, this.Name,
                this.Lastname, this.Address, this.City, this.Country, this.PhoneNumber, this.DateOfBirth);
        public static UserEntity ToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                Name = user.Name,
                Lastname = user.Lastname,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth
            };
        }
    }
}
