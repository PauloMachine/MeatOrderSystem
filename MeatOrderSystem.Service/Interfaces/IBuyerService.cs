using MeatOrderSystem.Application.DTOs;

namespace MeatOrderSystem.Service.Interfaces;

public interface IBuyerService
{
    Task<IEnumerable<BuyerDto>> GetAllAsync();
    Task<BuyerDto?> GetByIdAsync(int id);
    Task<BuyerDto> AddAsync(CreateBuyerDto dto);
    Task<BuyerDto?> UpdateAsync(int id, CreateBuyerDto dto);
    Task<(bool Success, string? Error)> DeleteAsync(int id);
}
