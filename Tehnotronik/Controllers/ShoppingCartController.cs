using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }   
        [HttpPost]
        [Route("/add-to-cart")]
        public async Task<bool> AddToCart(ShoppingCartItemRequest shoppingCartItemRequest)
        {
            var shoppingCart = await _shoppingCartRepository.GetById(shoppingCartItemRequest.ShoppingCartId);

            var shoppingCartId = Guid.NewGuid();

            if(shoppingCart == null)
            {
                await _shoppingCartRepository.CreateCart(new Domain.Models.ShoppingCart(shoppingCartId,
                    shoppingCartItemRequest.UserId, Array.Empty<ShoppingCartItem>()));
                await _shoppingCartRepository.AddToCart(shoppingCartId, new ShoppingCartItem(Guid.NewGuid(), shoppingCartItemRequest.ProductId,
                    shoppingCartItemRequest.Quantity));

                return true;
            }

            await _shoppingCartRepository.AddToCart(shoppingCart.Id, new ShoppingCartItem(Guid.NewGuid(), shoppingCartItemRequest.ProductId,
                shoppingCartItemRequest.Quantity));

            return true;
        }
    }
}
