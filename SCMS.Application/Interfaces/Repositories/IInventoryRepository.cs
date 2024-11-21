using SCMS.Domain.Entities;

namespace SCMS.Application.Interfaces.Repositories
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<Inventory> GetInventoryByProductIdAsync(Guid productId);
    }
}
