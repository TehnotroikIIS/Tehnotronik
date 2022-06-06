using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Requests;
using Tehnotronik.Interfaces.Repositories;

namespace Tehnotronik.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;
        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        [HttpPost]
        [Route("/create-sale")] 
        public async Task<bool> CreateAsync(SaleRequest saleRequest)
        {
            var existingSales = await _saleRepository.GetAllByProductId(saleRequest.ProductId);

            var overlapingSales = existingSales.Where(u => saleRequest.StartTime < u.EndTime && saleRequest.EndTime > u.StartTime);

            if (overlapingSales.Any()) return false;

            await _saleRepository.CreateAsync(new Domain.Models.Sale(Guid.NewGuid(), saleRequest.ProductId,
                saleRequest.Discount, saleRequest.StartTime, saleRequest.EndTime));

            return true;
        }
    }
}
