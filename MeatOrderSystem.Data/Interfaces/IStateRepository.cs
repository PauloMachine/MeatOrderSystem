using MeatOrderSystem.Model.Entities;

namespace MeatOrderSystem.Data.Interfaces;

public interface IStateRepository
{
    Task<IEnumerable<State>> GetAllAsync();
}