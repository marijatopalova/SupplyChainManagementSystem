using SCMS.Domain.Entities;

namespace SCMS.Domain.Interfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<Inventory> GetInventoryByProductIdAsync(Guid productId);
    }
}
