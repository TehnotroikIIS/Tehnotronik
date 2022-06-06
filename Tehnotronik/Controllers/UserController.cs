using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        [Route("/register")]
        public async Task<bool> RegisterAsync(UserRequest userRequest)
        {
            var user = await _userRepository.GetByEmailAsync(userRequest.Email);

            if (user != null) return false;

            await _userRepository.CreateAsync(new User(Guid.NewGuid(), userRequest.Email, userRequest.Username,
                BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(userRequest.Password))), userRequest.Name, userRequest.Lastname, userRequest.Address, userRequest.City,
                userRequest.Country, userRequest.PhoneNumber, userRequest.DateOfBirth));

            return true;
        }
        [HttpGet]
        [Route("/sign-in")]
        public async Task<User> SignIn(string email, string password)
        {
            var user = await _userRepository.GetByEmailAndPasswordAsync(email,
                BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password))));

            return user;
        }
        [HttpGet]
        [Route("/get-by-id")]
        public async Task<User> GetById(Guid id)
        {
            var result = await _userRepository.GetById(id);

            return result;
        }
    }
}
