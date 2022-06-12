﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class ShopOrderController : Controller
    {
        private readonly IShopOrderRepository _shopOrderRepository;
        private readonly IOrderRepository _orderRepository;
        public ShopOrderController(IShopOrderRepository shopOrderRepository, IOrderRepository orderRepository)
        {
            _shopOrderRepository = shopOrderRepository;
            _orderRepository = orderRepository;
        }
        [HttpPost]
        [Route("/shop-order")]
        public async Task<bool> CreateAsync(ShopOrderRequest shopOrderRequest)
        {
            var order = await _orderRepository.GetById(shopOrderRequest.OrderId);

            if (order == null) return false;

            await _shopOrderRepository.CreateAsync(new ShopOrder(Guid.NewGuid(), shopOrderRequest.UserId, shopOrderRequest.OrderId,
                new ShippingInformation(Guid.NewGuid(), shopOrderRequest.Address, shopOrderRequest.City,
                shopOrderRequest.Country, shopOrderRequest.PhoneNumber)));

            return true;
        }
        [HttpGet]
        [Route("/get-shopped-order")]
        public async Task<ShopOrder> GetById(Guid id)
        {
            var order = await _shopOrderRepository.GetById(id);

            return order;
        }
        [HttpGet]
        [Route("/user-orders")]
        public async Task<IReadOnlyList<ShopOrder>> GetByUserId(Guid userId)
        {
            return await _shopOrderRepository.GetByUserId(userId);
        }
    }
}
