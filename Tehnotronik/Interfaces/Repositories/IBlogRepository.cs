using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IBlogRepository
    {
        Task<bool> CreateAsync(Blog blog);
        Task<Blog> GetByIdAsync(Guid id);
        Task LikeAsync(Blog blog);
        Task DislikeAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task UpdateRateAsync(Guid blogId, double rate);
        Task AddComment(Blog blog);
    }
}
