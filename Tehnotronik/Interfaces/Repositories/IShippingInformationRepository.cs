using System;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface IShippingInformationRepository
    {
        Task<bool> CreateAsync(ShippingInformation shippingInformation);
        Task<ShippingInformation> GetById(Guid id);
    }
}
