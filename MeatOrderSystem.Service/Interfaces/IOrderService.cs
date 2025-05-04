using MeatOrderSystem.Application.DTOs;

namespace MeatOrderSystem.Service.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderWithTotalDto>> GetAllAsync(int? buyerId, DateTime? date);
    Task<OrderDto?> GetByIdAsync(int id);
    Task<OrderDto> AddAsync(CreateOrderDto dto);
    Task<bool> UpdateAsync(int id, CreateOrderDto dto);
    Task<bool> DeleteAsync(int id);
}
