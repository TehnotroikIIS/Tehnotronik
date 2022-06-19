using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class StorageController : Controller
    {
        private readonly IStorageOrderRepository _orderRepository;
        private readonly IStorageProductRepository _productRepository;

        public StorageController(IStorageOrderRepository orderRepository, IStorageProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("create-storage-order")]
        public async Task<bool> CreateStorageOrder(StorageOrderRequest request)
        {
            try
            {
                await _orderRepository.CreateAsync(new StorageOrder(request));
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        [HttpGet]
        [Route("/get-all-storage-orders")]
        public async Task<IReadOnlyList<StorageOrder>> GetAllStorageOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        [HttpGet]
        [Route("/sort-storage-orders-by-date-asc")]
        public async Task<IReadOnlyList<StorageOrder>> SortOrdersByDateAsc()
        {
            var result = await _orderRepository.GetAllOrders();

            return result.OrderBy(s => s.DeliveryDate).ToList();
        }

        [HttpGet]
        [Route("/sort-storage-orders-by-date-desc")]
        public async Task<IReadOnlyList<StorageOrder>> SortOrdersByDateDesc()
        {
            var result = await _orderRepository.GetAllOrders();

            return result.OrderByDescending(s => s.DeliveryDate).ToList();
        }
        [HttpGet]
        [Route("/sort-storage-orders-by-price-asc")]
        public async Task<IReadOnlyList<StorageOrder>> SortOrdersByPriceAsc()
        {
            var result = await _orderRepository.GetAllOrders();

            return result.OrderBy(s => s.Price).ToList();
        }

        [HttpGet]
        [Route("/sort-storage-orders-by-price-desc")]
        public async Task<IReadOnlyList<StorageOrder>> SortOrdersByPriceDesc()
        {
            var result = await _orderRepository.GetAllOrders();

            return result.OrderByDescending(s => s.Price).ToList();
        }

        [HttpDelete]
        [Route("confirm-arrived-storage-order")]
        public async Task<bool> ConfirmArrivedStorageOrder(ConfirmStorageOrderRequest request)
        {
            try
            {
                StorageOrder order = await _orderRepository.GetByIdAsync(request.OrderId);
                if (order == null) return false;

                order.Arrived = true;
                await _orderRepository.UpdateAsync(order);

                StorageProduct product = await _productRepository.GetByIdAsync(order.StorageProductId);
                if (product == null) return false;

                product.AvailableQuantity += order.Quantity;
                product.Quantity += order.Quantity;

                if(product.Location != request.Location)
                    product.Location = request.Location;

                await _productRepository.UpdateAsync(product);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        [HttpGet]
        [Route("get-location-recommendation")]
        public LocationEnum GetLocationRecommendation(StorageOrderRequest request)
        {
            if(request.Quantity >= 0 && request.Quantity < 20)
            {
                return LocationEnum.A1;
            } else if (request.Quantity >=20 && request.Quantity < 30)
            {
                return LocationEnum.A2;
            } else if(request.Quantity >= 30 && request.Quantity < 50)
            {
                return LocationEnum.A3;
            } else if (request.Quantity >= 50 && request.Quantity < 100)
            {
                return LocationEnum.B1;
            } else if (request.Quantity >= 100 && request.Quantity <150)
            {
                return LocationEnum.B2;
            } else
            {
               return LocationEnum.B3;
            }
        }
        [HttpGet]
        [Route("/get-product-location")]
        public async Task<LocationEnum> GetProductLocation(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            return product.Location;
        }
        [HttpPost]
        [Route("/create-storage-complaint")]
        public async Task<bool> CreateStorageComplaint(StorageComplaintRequest storageComplaintRequest)
        {
            await _productRepository.CreateStorgeComplaint(new StorageComplaint(storageComplaintRequest.ProductId, storageComplaintRequest.ProductId,
                storageComplaintRequest.WrongLocation, storageComplaintRequest.RightLocation));

            return true;
        }
        [HttpGet]
        [Route("/get-all-storage-complaints")]
        public async Task<IReadOnlyList<StorageComplaint>> GetAllStorageComplaints()
        {
            return await _productRepository.GetAllStorageComplaints();
        }
        [HttpPost]
        [Route("/set-minimal-quantity")]
        public async Task SetMinimalQuantity(MinimalQuantityRequest minimalQuantityRequest)
        {
            await _productRepository.UpdateMinimalQuantity(minimalQuantityRequest.StorageProductId, minimalQuantityRequest.MinimalQuantity);
        }
        [HttpGet]
        [Route("/order-recommendations")]
        public async Task<IReadOnlyList<StorageProduct>> GetRecommendations()
        {
            var products = await _productRepository.GetAllStorageProducts();

            foreach(var product in products)
            {
                if(product.AvailableQuantity <= 50)
                {
                    await _productRepository.UpdateStoragePriority(product.Id, PriorityEnum.MEDIUM);
                } else if(product.AvailableQuantity <= 20)
                {
                    await _productRepository.UpdateStoragePriority(product.Id, PriorityEnum.HIGH);
                } else
                {
                    await _productRepository.UpdateStoragePriority(product.Id, PriorityEnum.LOW);
                }
            }

            var updatedProducts = await _productRepository.GetAllStorageProducts();

            return updatedProducts.Where(s => s.Priority != PriorityEnum.LOW).ToList();
        }

        [HttpPost]
        [Route("/update-storage-product-quantity")]
        public async Task<bool> UpdateProductQuantity(StorageProductQuantityRequest request)
        {
            var product = await _productRepository.GetByIdAsync(request.StorageProductId);

            var minimalConstraintViolated = request.NewQuantity < product.MinimalQuantity;

            product.Quantity = request.NewQuantity;
            await _productRepository.UpdateAsync(product);

            return !minimalConstraintViolated;
        }
    }
}
