using System;
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
        [Route("createStorageOrder")]
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

        [HttpDelete]
        [Route("confirmArrivedStorageOrder")]
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
        [Route("getLocationRecommendation")]
        public async Task<LocationEnum> GetLocationRecommendation(StorageOrderRequest request)
        {

            return 0;
        }

    }
}
