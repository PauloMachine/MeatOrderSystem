using MeatOrderSystem.Model.Entities;

namespace MeatOrderSystem.Data.Interfaces;

public interface IMeatRepository
{
    Task<IEnumerable<Meat>> GetAllAsync();
    Task<Meat?> GetByIdAsync(int id);
    Task AddAsync(Meat meat);
    Task UpdateAsync(Meat meat);
    Task DeleteAsync(Meat meat);
    Task<bool> HasOrdersAsync(int meatId);
}
