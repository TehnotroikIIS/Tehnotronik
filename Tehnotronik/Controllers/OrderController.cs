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
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public OrderController(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }
        [HttpGet]
        [Route("/get-order")]
        public async Task<Order> GetById(Guid id)
        {
            return await _orderRepository.GetById(id);
        }
        [HttpPost]
        [Route("/create-order")]
        public async Task<bool> CreateAsync(OrderRequest orderRequest)
        {
            var shoppingCart = await _shoppingCartRepository.GetById(orderRequest.ShoppingCartId);

            var shoppingCartPrice = shoppingCart.ShoppingCartItems.Select(s => s.Price).Sum();

            await _orderRepository.CreateOrderAsync(new Order(Guid.NewGuid(), orderRequest.UserId, orderRequest.ShoppingCartId,
                shoppingCartPrice));

            await _shoppingCartRepository.DeleteById(orderRequest.ShoppingCartId);

            return true;
        }
    }
}
