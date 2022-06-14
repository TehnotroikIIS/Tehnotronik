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
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        [HttpPost]
        [Route("/create-blog")]
        public async Task<bool> CreateAsync(BlogRequest blogRequest)
        {
            await _blogRepository.CreateAsync(new Domain.Models.Blog(Guid.NewGuid(), blogRequest.Name, blogRequest.Text,
                Array.Empty<Guid>(), Array.Empty<Guid>(), 0));

            return true;
        }
        [HttpGet]
        [Route("/get-blog")]
        public async Task<Blog> GetByIdAsync(Guid id)
        {
            return await _blogRepository.GetByIdAsync(id);
        }
        [HttpPost]
        [Route("/like-blog")]
        public async Task<bool> LikeAsync(BlogReactionRequest blogReactionRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogReactionRequest.BlogId);

            if (blog == null) return false;

            var newLikes = blog.Likes == null ? new[] { blogReactionRequest.UserId } : blog.Likes.Append(blogReactionRequest.UserId).ToArray();

            await _blogRepository.LikeAsync(new Blog(blog.Id, blog.Name, blog.Text, newLikes, blog.Dislikes, blog.Rate));

            return true;
        }
        [HttpPost]
        [Route("/dislike-blog")]
        public async Task<bool> DislikeAsync(BlogReactionRequest blogReactionRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogReactionRequest.BlogId);

            if (blog == null) return false;

            var newDislikes = blog.Dislikes == null ? new[] { blogReactionRequest.UserId } : blog.Dislikes.Append(blogReactionRequest.UserId).ToArray();

            await _blogRepository.DislikeAsync(new Blog(blog.Id, blog.Name, blog.Text, blog.Likes, newDislikes, blog.Rate));

            return true;
        }
        [HttpPost]
        [Route("/remove-like")]
        public async Task<bool> RemoveLikeAsync(BlogReactionRequest blogReactionRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogReactionRequest.BlogId);

            if (blog == null) return false;

            var newLikes = blog.Likes.Where(u => u != blogReactionRequest.UserId).ToArray();

            await _blogRepository.LikeAsync(new Blog(blog.Id, blog.Name, blog.Text, newLikes, blog.Dislikes, blog.Rate));

            return true;
        }
        [HttpPost]
        [Route("/remove-dislike")]
        public async Task<bool> RemoveDislikeAsync(BlogReactionRequest blogReactionRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogReactionRequest.BlogId);

            if (blog == null) return false;

            var newDislikes = blog.Dislikes.Where(u => u != blogReactionRequest.UserId).ToArray();

            await _blogRepository.LikeAsync(new Blog(blog.Id, blog.Name, blog.Text, blog.Likes, newDislikes, blog.Rate));

            return true;
        }
    }
}
