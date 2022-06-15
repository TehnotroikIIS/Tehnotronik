using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class ShippingInformationController : Controller
    {
        private readonly IShippingInformationRepository _shippingInformationRepository;
        public ShippingInformationController(IShippingInformationRepository shippingInformationRepository)
        {
            _shippingInformationRepository = shippingInformationRepository;
        }
        [HttpPost]
        [Route("/add-shipping-info")]
        public async Task<bool> CreateAsync(ShippingInformationRequest shippingInformationRequest)
        {
            await _shippingInformationRepository.CreateAsync(new Domain.Models.ShippingInformation(Guid.NewGuid(), shippingInformationRequest.Address,
                shippingInformationRequest.City, shippingInformationRequest.Country, shippingInformationRequest.PhoneNumber));

            return true;
        }

    }
}
