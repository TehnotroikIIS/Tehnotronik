using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IFavoriteCategoriesRepository
    {
        Task<bool> Create(FavoriteCategories favoriteCategories);
        Task Update(FavoriteCategories favoriteCategories);
        Task<FavoriteCategories> GetByUserId(Guid userId);
    }
}
