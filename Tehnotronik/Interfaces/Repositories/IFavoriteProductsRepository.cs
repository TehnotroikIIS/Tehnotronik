using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IFavoriteProductsRepository
    {
        Task Create(FavoriteProducts favoriteProducts);
        Task Update(FavoriteProducts favoriteProducts);
        Task<FavoriteProducts> GetByUserId(Guid userId);
    }
}
