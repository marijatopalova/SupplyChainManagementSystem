using Microsoft.EntityFrameworkCore;
using SCMS.Application.Interfaces.Repositories;
using SCMS.Domain.Entities;
using SCMS.Infrastructure.Persistence;

namespace SCMS.Infrastructure.Repositories
{
    public class InventoryRepository(AppDbContext dbContext) : IInventoryRepository
    {
        public async Task AddAsync(Inventory entity)
        {
            dbContext.Inventories.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Inventory entity)
        {
            dbContext.Inventories.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Inventory>> GetAllAsync()
        {
            return await dbContext.Inventories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Inventory> GetByIdAsync(Guid id)
        {
            return await dbContext.Inventories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Inventory> GetInventoryByProductIdAsync(Guid productId)
        {
            return await dbContext.Inventories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task UpdateAsync(Inventory entity)
        {
            dbContext.Inventories.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
