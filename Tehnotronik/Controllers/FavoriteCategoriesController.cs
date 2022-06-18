using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class FavoriteCategoriesController : Controller
    {
        private readonly IFavoriteCategoriesRepository _favoriteCategoriesRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FavoriteCategoriesController(IFavoriteCategoriesRepository favoriteCategoriesRepository, ICategoryRepository categoryRepository)
        {
            _favoriteCategoriesRepository = favoriteCategoriesRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Route("/add-to-favorite-categories")]
        public async Task<bool> AddToFavorites([FromBody]FavoriteCategoriesRequest favoriteCategoriesRequest)
        {
            var userFavorites = await _favoriteCategoriesRepository.GetByUserId(favoriteCategoriesRequest.UserId);

            if (userFavorites == null)
            {
                var favorites = new FavoriteCategories(favoriteCategoriesRequest.UserId, favoriteCategoriesRequest.UserId, new[] { favoriteCategoriesRequest.CategoryId });

                await _favoriteCategoriesRepository.Create(favorites);

                return true;
            }
            else
            {
                var favoriteCategories = userFavorites.Categories ?? Array.Empty<Guid>();

                var favorites = favoriteCategories.Append(favoriteCategoriesRequest.CategoryId).ToArray();

                await _favoriteCategoriesRepository.Update(new FavoriteCategories(favoriteCategoriesRequest.UserId, favoriteCategoriesRequest.UserId, favorites));

                return true;
            }
        }
        [HttpPost]
        [Route("/remove-from-favorite-categories")]
        public async Task<bool> RemoveFromFavorite([FromBody] FavoriteCategoriesRequest favoriteCategoriesRequest)
        {
            var userFavorites = await _favoriteCategoriesRepository.GetByUserId(favoriteCategoriesRequest.UserId);

            var favoriteCategories = userFavorites.Categories ?? Array.Empty<Guid>();

            var favorites = favoriteCategories.Where(u => u != favoriteCategoriesRequest.CategoryId).ToArray();

            await _favoriteCategoriesRepository.Update(new FavoriteCategories(favoriteCategoriesRequest.UserId, favoriteCategoriesRequest.UserId, favorites));

            return true;
        }
        [HttpGet]
        [Route("/get-favorite-categories")]
        public async Task<IReadOnlyList<Guid>> GetFavoritesByUserId(Guid userId)
        {
            var userFavs = await _favoriteCategoriesRepository.GetByUserId(userId);

            var categories = new List<Guid>();

            foreach (var id in userFavs.Categories)
            {
                //var category = await _categoryRepository.GetById(id);

                categories.Add(id);
            }

            return categories;
        }
    }
}
