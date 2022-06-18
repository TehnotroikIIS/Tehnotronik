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
        public async Task<bool> CreateAsync([FromBody] BlogRequest blogRequest)
        {
            await _blogRepository.CreateAsync(new Domain.Models.Blog(Guid.NewGuid(), blogRequest.Name, blogRequest.CategoryId, blogRequest.ProductId, blogRequest.Text,
                Array.Empty<Guid>(), Array.Empty<Guid>(), 0, 0, Array.Empty<Comment>(), DateTime.Now));

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
        public async Task<bool> LikeAsync([FromBody]BlogReactionRequest blogReactionRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogReactionRequest.BlogId);

            if (blog == null) return false;

            var newLikes = blog.Likes == null ? new[] { blogReactionRequest.UserId } : blog.Likes.Append(blogReactionRequest.UserId).ToArray();

            await _blogRepository.LikeAsync(new Blog(blog.Id, blog.Name, blog.CategoryId, blog.ProductId, blog.Text, 
                newLikes, blog.Dislikes, blog.Rate, blog.NumberOfRates, blog.Comments, blog.DateOfPublishing));

            return true;
        }
        [HttpPost]
        [Route("/dislike-blog")]
        public async Task<bool> DislikeAsync([FromBody] BlogReactionRequest blogReactionRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogReactionRequest.BlogId);

            if (blog == null) return false;

            var newDislikes = blog.Dislikes == null ? new[] { blogReactionRequest.UserId } : blog.Dislikes.Append(blogReactionRequest.UserId).ToArray();

            await _blogRepository.DislikeAsync(new Blog(blog.Id, blog.Name, blog.CategoryId, blog.ProductId, blog.Text,
                blog.Likes, newDislikes, blog.Rate, blog.NumberOfRates, blog.Comments, blog.DateOfPublishing));

            return true;
        }
        [HttpPost]
        [Route("/remove-like")]
        public async Task<bool> RemoveLikeAsync([FromBody] BlogReactionRequest blogReactionRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogReactionRequest.BlogId);

            if (blog == null) return false;

            var newLikes = blog.Likes.Where(u => u != blogReactionRequest.UserId).ToArray();

            await _blogRepository.LikeAsync(new Blog(blog.Id, blog.Name, blog.CategoryId, blog.ProductId, blog.Text, 
                newLikes, blog.Dislikes, blog.Rate, blog.NumberOfRates, blog.Comments, blog.DateOfPublishing));

            return true;
        }
        [HttpPost]
        [Route("/remove-dislike")]
        public async Task<bool> RemoveDislikeAsync([FromBody] BlogReactionRequest blogReactionRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogReactionRequest.BlogId);

            if (blog == null) return false;

            var newDislikes = blog.Dislikes.Where(u => u != blogReactionRequest.UserId).ToArray();

            await _blogRepository.LikeAsync(new Blog(blog.Id, blog.Name, blog.CategoryId, blog.ProductId, blog.Text, 
                blog.Likes, newDislikes, blog.Rate, blog.NumberOfRates, blog.Comments, blog.DateOfPublishing));

            return true;
        }
        [HttpPost]
        [Route("/add-comment")]
        public async Task<bool> AddCommentAsync([FromBody] BlogCommentRequest blogCommentRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogCommentRequest.BlogId);

            if (blog == null) return false;

            var comments = blog.Comments == null ? new[] { new Comment(Guid.NewGuid(), blogCommentRequest.UserId, blogCommentRequest.Text) }
                            : blog.Comments.Append(new Comment(Guid.NewGuid(), blogCommentRequest.UserId, blogCommentRequest.Text)).ToArray();

            await _blogRepository.AddComment(new Blog(blog.Id, blog.Name, blog.CategoryId, blog.ProductId, blog.Text, blog.Likes, 
                blog.Dislikes, blog.Rate, blog.NumberOfRates, comments, blog.DateOfPublishing));

            return true;
        }
        [HttpPost]
        [Route("/update-blog")]
        public async Task UpdateAsync([FromBody] BlogUpdateRequest blogUpdateRequest)
        {
            await _blogRepository.UpdateAsync(blogUpdateRequest);
        }
        [HttpDelete]
        [Route("/delete-blog")]
        public async Task DeleteByIdAsync(Guid id)
        {
            await _blogRepository.DeleteById(id);
        }
        [HttpGet]
        [Route("/blogs-by-category")]
        public async Task<IReadOnlyList<Blog>> GetByCategoryId(Guid categoryId)
        {
            return await _blogRepository.GetByCategoryId(categoryId);
        }
        [HttpGet]
        [Route("/sort-by-date-asc")]
        public async Task<IReadOnlyList<Blog>> SortByDateAsync()
        {
            var blogs = await _blogRepository.GetAll();

            var sortedBlogs = blogs.OrderBy(s => s.DateOfPublishing);

            return sortedBlogs.ToList();
        }
        [HttpGet]
        [Route("/sort-by-date-desc")]
        public async Task<IReadOnlyList<Blog>> SortByDateDesc()
        {
            var blogs = await _blogRepository.GetAll();

            var sortedBlogs = blogs.OrderByDescending(s => s.DateOfPublishing);

            return sortedBlogs.ToList();
        }
        [HttpGet]
        [Route("/sort-by-rate-asc")]
        public async Task<IReadOnlyList<Blog>> SortByRateAsync()
        {
            var blogs = await _blogRepository.GetAll();

            var sortedBlogs = blogs.OrderBy(s => s.Rate);

            return sortedBlogs.ToList();
        }
        [HttpGet]
        [Route("/sort-by-rate-desc")]
        public async Task<IReadOnlyList<Blog>> SortByRateDesc()
        {
            var blogs = await _blogRepository.GetAll();

            var sortedBlogs = blogs.OrderByDescending(s => s.Rate);

            return sortedBlogs.ToList();
        }
        [HttpPost]
        [Route("/rate-blog")]
        public async Task<bool> RateAsync([FromBody] BlogRateRequest blogRateRequest)
        {
            var blog = await _blogRepository.GetByIdAsync(blogRateRequest.BlogId);

            if (blog == null) return false;

            var newNumberOfReviews = blog.NumberOfRates++;
            var newRate = Math.Ceiling((blog.Rate * blog.NumberOfRates + blogRateRequest.Rate) / (newNumberOfReviews));

            await _blogRepository.UpdateRateAsync(blogRateRequest.BlogId, newRate, newNumberOfReviews);

            return true;
        }
    }
}
