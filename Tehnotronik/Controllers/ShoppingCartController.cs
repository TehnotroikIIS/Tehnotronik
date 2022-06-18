using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        [HttpPost]
        [Route("/create-cart")]
        public async Task<bool> CreateAsync([FromBody] ShoppingCartRequest cartRequest)
        {
            await _shoppingCartRepository.CreateCart(new Domain.Models.ShoppingCart(Guid.NewGuid(),cartRequest.UserId, Array.Empty<ShoppingCartItem>()));

            return true;
        }
        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }
        [HttpPost]
        [Route("/add-to-cart")]
        public async Task<bool> AddToCart([FromBody] ShoppingCartItemRequest shoppingCartItemRequest)
        {
            var shoppingCart = await _shoppingCartRepository.GetById(shoppingCartItemRequest.ShoppingCartId);
            var product = await _productRepository.GetByIdAsync(shoppingCartItemRequest.ProductId);

            var price = product.Price * shoppingCartItemRequest.Quantity;

            var shoppingCartId = Guid.NewGuid();

            if(shoppingCart == null)
            {
                await _shoppingCartRepository.CreateCart(new Domain.Models.ShoppingCart(shoppingCartId,
                    shoppingCartItemRequest.UserId, Array.Empty<ShoppingCartItem>()));
                await _shoppingCartRepository.AddToCart(shoppingCartId, new ShoppingCartItem(Guid.NewGuid(), shoppingCartItemRequest.ProductId,
                    price, shoppingCartItemRequest.Quantity));

                return true;
            }

            await _shoppingCartRepository.AddToCart(shoppingCart.Id, new ShoppingCartItem(Guid.NewGuid(), shoppingCartItemRequest.ProductId, price,
                shoppingCartItemRequest.Quantity));

            return true;
        }
        [HttpPost]
        [Route("/remove-from-cart")]
        public async Task<bool> RemoveFromCart([FromBody] ShoppingCartRemoveRequest shoppingCartRemoveRequest)
        {
            var shoppingCart = await _shoppingCartRepository.GetById(shoppingCartRemoveRequest.ShoppingCartId);

            var items = shoppingCart.ShoppingCartItems;
            var newItems = items.Where(s => s.Id != shoppingCartRemoveRequest.ShoppingCartItemId);

            await _shoppingCartRepository.RemoveFromCart(new ShoppingCart(shoppingCart.Id, shoppingCart.UserId,
                newItems.ToArray()));

            return true;
        }
        [HttpGet]
        [Route("/get-shopping-cart")]
        public async Task<ShoppingCart> GetById(Guid id)
        {
            return await _shoppingCartRepository.GetById(id);
        }

        [HttpGet]
        [Route("/get-cart-by-userId")]
        public async Task<ShoppingCart> GetByUserId(Guid userId)
        {
            return await _shoppingCartRepository.GetByUserId(userId);
        }
    }
}
