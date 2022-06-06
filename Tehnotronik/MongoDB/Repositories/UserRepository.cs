using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public UserRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task CreateAsync(User user)
        {
            await _queryExecutor.CreateAsync(UserEntity.ToUserEntity(user));
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {

            var filter = Builders<UserEntity>.Filter.Eq(u => u.Email, email)
                & Builders<UserEntity>.Filter.Eq(u => u.Password, password);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.FirstOrDefault()?.ToUser() ?? null;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Email, email);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.FirstOrDefault()?.ToUser() ?? null;
        }
    }
}
