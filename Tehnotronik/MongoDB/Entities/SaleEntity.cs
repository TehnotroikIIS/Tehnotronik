using System;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.MongoDB.Entities
{
    public class SaleEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public int Discount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Sale ToSale()
            => new Sale(this.Id, this.ProductId, this.Discount, this.StartTime, this.EndTime);
        public static SaleEntity ToSaleEntity(Sale sale)
        {
            return new SaleEntity
            {
                Id = sale.Id,
                ProductId = sale.ProductId,
                Discount = sale.Discount,
                StartTime = sale.StartTime,
                EndTime = sale.EndTime
            };
        }
    }
}
