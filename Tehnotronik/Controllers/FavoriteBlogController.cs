using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Domain.Models;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class FavoriteBlogController : Controller
    {
        private readonly IFavoriteBlogRepository _favoriteBlogRepository;
        private readonly IBlogRepository _blogRepository;
        public FavoriteBlogController(IFavoriteBlogRepository favoriteBlogRepository, IBlogRepository blogRepository)
        {
            _favoriteBlogRepository = favoriteBlogRepository;
            _blogRepository = blogRepository;
        }
        [HttpPost]
        [Route("/add-to-favorites")]
        public async Task<bool> AddToFavorites(FavoriteBlogRequest favoriteBlogRequest)
        {
            var userFavorites = await _favoriteBlogRepository.GetByUserId(favoriteBlogRequest.UserId);

            if(userFavorites == null)
            {
                var favorites = new FavoriteBlog(favoriteBlogRequest.UserId, favoriteBlogRequest.UserId, new[] { favoriteBlogRequest.BlogId });

                await _favoriteBlogRepository.CreateAsync(favorites);

                return true;
            }
            else
            {
                var favoriteBlogs = userFavorites.Blogs ?? Array.Empty<Guid>();

                var favorites = favoriteBlogs.Append(favoriteBlogRequest.BlogId).ToArray();

                await _favoriteBlogRepository.UpdateList(new FavoriteBlog(favoriteBlogRequest.UserId, favoriteBlogRequest.UserId, favorites));

                return true;
            }
        }
        [HttpPost]
        [Route("/remove-from-favorites")]
        public async Task<bool> RemoveFromFavorites(FavoriteBlogRequest favoriteBlogRequest)
        {
            var userFavorites = await _favoriteBlogRepository.GetByUserId(favoriteBlogRequest.UserId);

            var favoriteBlogs = userFavorites.Blogs ?? Array.Empty<Guid>();

            var favorites = favoriteBlogs.Where(u => u != favoriteBlogRequest.BlogId).ToArray();

            await _favoriteBlogRepository.UpdateList(new FavoriteBlog(favoriteBlogRequest.UserId, favoriteBlogRequest.UserId, favorites));

            return true;
        }
        [HttpGet]
        [Route("/get-favorite-blogs")]
        public async Task<IReadOnlyList<Blog>> GetFavoritesByUserId(Guid userId)
        {
            var userFavs = await _favoriteBlogRepository.GetByUserId(userId);

            var blogs = new List<Blog>();

            foreach(var id in userFavs.Blogs)
            {
                var blog = await _blogRepository.GetByIdAsync(id);

                blogs.Add(blog);
            }

            return blogs;
        }
    }
}
