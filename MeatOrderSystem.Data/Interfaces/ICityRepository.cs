using MeatOrderSystem.Model.Entities;

namespace MeatOrderSystem.Data.Interfaces;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllAsync();
    Task<IEnumerable<City>> GetByStateIdAsync(int stateId);
}