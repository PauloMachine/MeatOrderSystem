using MeatOrderSystem.Application.DTOs;

namespace MeatOrderSystem.Service.Interfaces;

public interface IStateService
{
    Task<IEnumerable<StateDto>> GetAllAsync();
}