using MeatOrderSystem.Model.Entities;

namespace MeatOrderSystem.Data.Interfaces;

public interface IBuyerRepository
{
    Task<IEnumerable<Buyer>> GetAllAsync();
    Task<Buyer?> GetByIdAsync(int id);
    Task AddAsync(Buyer buyer);
    Task UpdateAsync(Buyer buyer);
    Task DeleteAsync(Buyer buyer);
    Task<bool> HasOrdersAsync(int buyerId);
}
