using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IBlogRepository
    {
        Task<bool> CreateAsync(Blog blog);
        Task<Blog> GetByIdAsync(Guid id);
        Task LikeAsync(Blog blog);
        Task DislikeAsync(Blog blog);
        Task UpdateAsync(BlogUpdateRequest blogUpdateRequest);
        Task UpdateRateAsync(Guid blogId, double rate);
        Task AddComment(Blog blog);
        Task DeleteById(Guid id);
        Task<IReadOnlyList<Blog>> GetByCategoryId(Guid categoryId);
        Task<IReadOnlyCollection<Blog>> GetAll();
    }
}
