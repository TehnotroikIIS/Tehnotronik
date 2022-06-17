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
    public class ProductReviewController : Controller
    {
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IProductRepository _productRepository;
        public ProductReviewController(IProductReviewRepository productReviewRepository, IProductRepository productRepository)
        {
            _productReviewRepository = productReviewRepository;
            _productRepository = productRepository;
        }
        [HttpPost]
        [Route("/add-review")]
        public async Task<bool> CreateReviewAsync([FromBody] ReviewRequest reviewRequest)
        {
            var productReview = await _productReviewRepository.GetByProductId(reviewRequest.ProductId);

            if(productReview == null)
            {
                await _productReviewRepository.CreateAsync(new Domain.Models.ProductReview(Guid.NewGuid(), reviewRequest.ProductId,
                    new[] { new Review(Guid.NewGuid(), reviewRequest.UserId, reviewRequest.Text, reviewRequest.Rate) }));

                await _productRepository.UpdateRateAsync(reviewRequest.ProductId, reviewRequest.Rate, 1);

                return true;
            }

            var reviews = productReview.Reviews == null ? new[] { new Review(Guid.NewGuid(), reviewRequest.UserId, reviewRequest.Text, reviewRequest.Rate) }
                                                : productReview.Reviews.Append(new Review(Guid.NewGuid(), reviewRequest.UserId, reviewRequest.Text, reviewRequest.Rate));

            productReview.Reviews = reviews.ToArray();

            await _productReviewRepository.AddReviewAsync(productReview);

            var product = await _productRepository.GetByIdAsync(reviewRequest.ProductId);

            var newNumberOfReviews = product.NumberOfReviews++;
            var newRate = Math.Ceiling((product.Rate * product.NumberOfReviews + reviewRequest.Rate) / (newNumberOfReviews));

            await _productRepository.UpdateRateAsync(reviewRequest.ProductId, newRate, newNumberOfReviews);

            return true;
        }
        [HttpGet]
        [Route("/get-reviews")]
        public async Task<IReadOnlyList<Review>> GetByProductIdAsync(Guid productId)
        {
            var productReview =  await _productReviewRepository.GetByProductId(productId);

            if (productReview == null) return new List<Review>();

            return productReview.Reviews.ToList();
        }
    }
}
