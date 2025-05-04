using MeatOrderSystem.Application.DTOs;

namespace MeatOrderSystem.Service.Interfaces;

public interface IMeatService
{
    Task<IEnumerable<MeatDto>> GetAllAsync();
    Task<MeatDto?> GetByIdAsync(int id);
    Task<MeatDto> AddAsync(CreateMeatDto dto);
    Task<MeatDto> UpdateAsync(int id, CreateMeatDto dto);
    Task<(bool Success, string? Error)> DeleteAsync(int id);
}



