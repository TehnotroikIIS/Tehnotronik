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
    public class FavoriteProductsController : Controller
    {
        private readonly IFavoriteProductsRepository _favoriteProductsRepository;
        private readonly IProductRepository _productRepository;

        public FavoriteProductsController(IFavoriteProductsRepository favoriteProductsRepository, IProductRepository productRepository)
        {
            _favoriteProductsRepository = favoriteProductsRepository;
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("/add-to-favorite-products")]
        public async Task<bool> AddToFavorites(FavoriteProductsRequest favoriteProductRequest)
        {
            var userFavorites = await _favoriteProductsRepository.GetByUserId(favoriteProductRequest.UserId);

            if (userFavorites == null)
            {
                var favorites = new FavoriteProducts(favoriteProductRequest.UserId, favoriteProductRequest.UserId, new[] { favoriteProductRequest.ProductId });

                await _favoriteProductsRepository.Create(favorites);

                return true;
            }
            else
            {
                var favoriteProducts = userFavorites.Products ?? Array.Empty<Guid>();

                var favorites = favoriteProducts.Append(favoriteProductRequest.ProductId).ToArray();

                await _favoriteProductsRepository.Update(new FavoriteProducts(favoriteProductRequest.UserId, favoriteProductRequest.UserId, favorites));

                return true;
            }
        }
        [HttpPost]
        [Route("/remove-from-favorite-products")]
        public async Task<bool> RemoveFromFavorites(FavoriteProductsRequest favoriteProductsRequest)
        {
            var userFavorites = await _favoriteProductsRepository.GetByUserId(favoriteProductsRequest.UserId);

            var favoriteProducts = userFavorites.Products ?? Array.Empty<Guid>();

            var favorites = favoriteProducts.Where(u => u != favoriteProductsRequest.ProductId).ToArray();

            await _favoriteProductsRepository.Update(new FavoriteProducts(favoriteProductsRequest.UserId, favoriteProductsRequest.UserId, favorites));

            return true;
        }
        [HttpGet]
        [Route("/get-favorite-products")]
        public async Task<IReadOnlyList<Product>> GetFavoritesByUserId(Guid userId)
        {
            var userFavs = await _favoriteProductsRepository.GetByUserId(userId);

            var products = new List<Product>();

            foreach (var id in userFavs.Products)
            {
                var blog = await _productRepository.GetByIdAsync(id);

                products.Add(blog);
            }

            return products;
        }
    }
}
