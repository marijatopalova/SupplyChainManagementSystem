using SCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Application.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByNameAsync(string name);
    }
}
