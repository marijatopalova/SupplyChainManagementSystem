using Microsoft.EntityFrameworkCore;
using SCMS.Domain.Entities;
using SCMS.Domain.Interfaces;
using SCMS.Infrastructure.Persistence;

namespace SCMS.Infrastructure.Repositories
{
    public class OrderRepository(AppDbContext dbContext) : IOrderRepository
    {
        public async Task AddAsync(Order entity)
        {
            dbContext.Orders.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            dbContext.Orders.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await dbContext.Orders
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await dbContext.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> GetOrderWithItemsAsync(Guid orderId)
        {
            return await dbContext.Orders
                .Include(x => x.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task UpdateAsync(Order entity)
        {
            dbContext.Orders.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
