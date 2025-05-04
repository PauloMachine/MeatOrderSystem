using MeatOrderSystem.Application.DTOs;

namespace MeatOrderSystem.Service.Interfaces;

public interface IMeatOriginService
{
    Task<IEnumerable<MeatOriginDto>> GetAllAsync();
}