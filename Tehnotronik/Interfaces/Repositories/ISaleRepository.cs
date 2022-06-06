using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehnotronik.Domain.Models;

namespace Tehnotronik.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        Task CreateAsync(Sale sale);
    }
}
