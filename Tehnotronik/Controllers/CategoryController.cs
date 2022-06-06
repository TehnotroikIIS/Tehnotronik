using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        [Route("/create-category")]
        public async Task<bool> CreateCategoryAsync(CategoryRequest categoryRequest)
        {
            await _categoryRepository.CreateAsync(new Domain.Models.Category(Guid.NewGuid(), categoryRequest.Name));

            return true;
        }
        [HttpGet]
        [Route("/all-categories")]
        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }
        [HttpGet]
        [Route("/get-category-by-id")]
        public async Task<Category> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }
    }
}
