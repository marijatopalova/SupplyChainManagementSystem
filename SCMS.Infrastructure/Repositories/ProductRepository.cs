using Microsoft.EntityFrameworkCore;
using SCMS.Application.Interfaces.Repositories;
using SCMS.Domain.Entities;
using SCMS.Infrastructure.Persistence;

namespace SCMS.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public async Task AddAsync(Product entity)
        {
            dbContext.Products.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            dbContext.Products.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await dbContext.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task UpdateAsync(Product entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
