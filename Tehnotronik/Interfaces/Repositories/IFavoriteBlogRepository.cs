using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IFavoriteBlogRepository
    {
        Task<bool> CreateAsync(FavoriteBlog favoriteBlog);
        Task UpdateList(FavoriteBlog favoriteBlog);
        Task<FavoriteBlog> GetByUserId(Guid userId);
    }
}
