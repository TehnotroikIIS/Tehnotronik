using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;
using Tehnotronik.MongoDB.Common;
using Tehnotronik.MongoDB.Entities;

namespace Tehnotronik.MongoDB.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public BlogRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task<bool> CreateAsync(Blog blog)
        {
            await _queryExecutor.CreateAsync(BlogEntity.ToBlogEntity(blog));

            return true;
        }

        public async Task DislikeAsync(Blog blog)
        {
            var filter = Builders<BlogEntity>.Filter.Eq(u => u.Id, blog.Id);

            var update = Builders<BlogEntity>.Update
                .Set(u => u.Dislikes, blog.Dislikes);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task<Blog> GetByIdAsync(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<BlogEntity>(id);

            return result?.ToBlog() ?? null;
        }

        public async Task LikeAsync(Blog blog)
        {
            var filter = Builders<BlogEntity>.Filter.Eq(u => u.Id, blog.Id);

            var update = Builders<BlogEntity>.Update
                .Set(u => u.Likes, blog.Likes);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task UpdateAsync(BlogUpdateRequest blog)
        {
            var filter = Builders<BlogEntity>.Filter.Eq(u => u.Id, blog.Id);

            var update = Builders<BlogEntity>.Update
                .Set(u => u.Name, blog.Name)
                .Set(u => u.Text, blog.Text);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task UpdateRateAsync(Guid blogId, double rate)
        {
            var filter = Builders<BlogEntity>.Filter.Eq(u => u.Id, blogId);

            var update = Builders<BlogEntity>.Update
                .Set(u => u.Rate, rate);

            await _queryExecutor.UpdateAsync(filter, update);
        }
        public async Task AddComment(Blog blog)
        {
            var filter = Builders<BlogEntity>.Filter.Eq(u => u.Id, blog.Id);

            var update = Builders<BlogEntity>.Update
                .Set(u => u.Comments, blog.Comments.Select(s => CommentEntity.ToCommentEntity(s)));

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task DeleteById(Guid id)
        {
            var filter = Builders<BlogEntity>.Filter.Eq(u => u.Id, id);

            await _queryExecutor.DeleteByIdAsync(filter);
        }

        public async Task<IReadOnlyList<Blog>> GetByCategoryId(Guid categoryId)
        {
            var filter = Builders<BlogEntity>.Filter.Eq(u => u.CategoryId, categoryId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.Select(s => s.ToBlog())?.ToList() ?? new List<Blog>();
        }
    }
}
