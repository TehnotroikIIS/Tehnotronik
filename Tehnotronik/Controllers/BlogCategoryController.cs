using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class BlogCategoryController : Controller
    {
        private readonly IBlogCategoryRepository _categoryRepository;
        public BlogCategoryController(IBlogCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        [Route("/create-blog-category")]
        public async Task<bool> CreateCategoryAsync([FromBody] CategoryRequest categoryRequest)
        {
            await _categoryRepository.CreateAsync(new Domain.Models.BlogCategory(Guid.NewGuid(), categoryRequest.Name));

            return true;
        }
        [HttpGet]
        [Route("/all-blog-categories")]
        public async Task<List<BlogCategory>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }
        [HttpGet]
        [Route("/get-blog-category-by-id")]
        public async Task<BlogCategory> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }
    }
}
