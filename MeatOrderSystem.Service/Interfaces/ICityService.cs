using MeatOrderSystem.Application.DTOs;

namespace MeatOrderSystem.Service.Interfaces;

public interface ICityService
{
    Task<IEnumerable<CityDto>> GetAllAsync();
    Task<IEnumerable<CityDto>> GetByStateIdAsync(int stateId);
}