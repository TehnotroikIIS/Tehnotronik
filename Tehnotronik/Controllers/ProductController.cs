using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Tehnotronik.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IStorageProductRepository _storageProductRepository;
        public ProductController(IProductRepository productRepository, IStorageProductRepository storageProductRepository)
        {
            _productRepository = productRepository;
            _storageProductRepository = storageProductRepository;
        }
        [HttpPost]
        [Route("/create-product")]
        public async Task<bool> CreateAsync([FromBody]ProductRequest productRequest)
        {
            var productId = Guid.NewGuid(); 

            await _productRepository.CreateAsync(new Domain.Models.Product(productId, productRequest.Name, productRequest.Price,
                productRequest.Description, productRequest.Manufacturer, productRequest.TechnicalDescription, productRequest.CategoryId, productRequest.Rate,
                productRequest.NumberOfReviews, productRequest.IsAvailable, 0, 0, 0));

            await _storageProductRepository.CreateAsync(new StorageProduct(Guid.NewGuid(), productId, LocationEnum.A1, 0, 0, 0, PriorityEnum.LOW, SKUEnum.Box, 10));

            return true;
        }
        [HttpGet]
        [Route("/get-product-id")]
        public async Task<Product> GetById(Guid id)
        {
            var result = await _productRepository.GetByIdAsync(id);

            return result;
        }
        [HttpPost]
        [Route("/update-product")]
        public async Task<bool> UpdateProduct([FromBody]ProductUpdateRequest productUpdateRequest)
        {
            await _productRepository.UpdateAsync(productUpdateRequest.Id, productUpdateRequest.Name,
                productUpdateRequest.Price, productUpdateRequest.Description, productUpdateRequest.Manufacturer,
                productUpdateRequest.TechnicalDescription);

            return true;
        }
        [HttpPost]
        [Route("/update-availability")]
        public async Task UpdateAvailability(Guid id, bool isAvailable)
        {
            await _productRepository.UpdateAvailabilityById(id, isAvailable);
        }
        [HttpGet]
        [Route("/get-by-category-id")]
        public async Task<List<Product>> GetByCategoryId(Guid categoryId)
        {
            var result = await _productRepository.GetByCategoryId(categoryId);

            return result;
        }
        [HttpGet]
        [Route("/search-product")]
        public async Task<List<Product>> SearchByName(string name)
        {
            return await _productRepository.SearchByName(name);
        }
        [HttpGet]
        [Route("/get-all-products")]
        public async Task<IReadOnlyList<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }
        [HttpGet]
        [Route("/price-scope")]
        public async Task<IReadOnlyList<Product>> GetBetweenPrices(double minPrice, double maxPrice)
        {
            return await _productRepository.GetAllBetweenPricesAsync(minPrice, maxPrice);
        }
        [HttpGet]
        [Route("/get-available-products")]
        public async Task<IReadOnlyList<Product>> GetAllAvailableAsync()
        {
            return await _productRepository.GetAllAvailableAsync();
        }
        [HttpGet]
        [Route("/get-top5-week")]
        public async Task<IReadOnlyList<Product>> GetTop5Week()
        {
            return await _productRepository.GetTop5Week();
        }
        [HttpGet]
        [Route("/get-top5-month")]
        public async Task<IReadOnlyList<Product>> GetTop5Month()
        {
            return await _productRepository.GetTop5Month();
        }
        [HttpGet]
        [Route("/get-top5-year")]
        public async Task<IReadOnlyList<Product>> GetTop5Year()
        {
            return await _productRepository.GetTop5Year();
        }
        [HttpDelete]
        [Route("/delete-product")]
        public async Task RemoveProduct(Guid id)
        {
            await _productRepository.DeleteById(id);
        }
        [HttpGet]
        [Route("/sort-by-price-asc")]
        public async Task<IReadOnlyList<Product>> SortByPriceAsc(Guid categoryId)
        {
            var products = await _productRepository.GetByCategoryId(categoryId);

            return products?.OrderBy(a => a.Price)?.ToList() ?? new List<Product>();
        }
        [HttpGet]
        [Route("/sort-by-price-desc")]
        public async Task<IReadOnlyList<Product>> SortByPriceDesc(Guid categoryId)
        {
            var products = await _productRepository.GetByCategoryId(categoryId);

            return products?.OrderByDescending(a => a.Price)?.ToList() ?? new List<Product>();
        }
      /*  [HttpGet]
        [Route("/pdf-products")]
        public async Task GeneratePDF()
        {
            var products = await _productRepository.GetAllAsync();
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.Body);
                pdfDoc.Open();
                Paragraph Text = new Paragraph("This is test file");
                pdfDoc.Add(Text);
                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
            }
            catch (Exception ex)
            { 
                //Response.Write(ex.Message); 
            
            }
        }*/
    } 
}
