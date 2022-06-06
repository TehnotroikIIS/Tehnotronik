using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost]
        [Route("/create-product")]
        public async Task<bool> CreateAsync(ProductRequest productRequest)
        {
            await _productRepository.CreateAsync(new Domain.Models.Product(Guid.NewGuid(), productRequest.Name, productRequest.Price,
                productRequest.Description, productRequest.Manufacturer, productRequest.TechnicalDescription, productRequest.Rate,
                productRequest.NumberOfReviews, productRequest.IsAvailable, 0, 0, 0));

            return true;
        }
        [HttpGet]
        [Route("/get-by-id")]
        public async Task<Product> GetById(Guid id)
        {
            var result = await _productRepository.GetByIdAsync(id);

            return result;
        }
        [HttpPost]
        [Route("/update-product")]
        public async Task<bool> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            await _productRepository.UpdateAsync(productUpdateRequest.Id, productUpdateRequest.Name,
                productUpdateRequest.Price, productUpdateRequest.Description, productUpdateRequest.Manufacturer,
                productUpdateRequest.TechnicalDescription);

            return true;
        }
    }
}
