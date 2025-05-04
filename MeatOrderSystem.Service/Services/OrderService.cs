using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using MeatOrderSystem.Service.Interfaces;

namespace MeatOrderSystem.Service.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly ICurrencyConverterService _converter;

    public OrderService(IOrderRepository repository, ICurrencyConverterService converter)
    {
        _repository = repository;
        _converter = converter;
    }

    public async Task<IEnumerable<OrderWithTotalDto>> GetAllAsync(int? buyerId, DateTime? date)
    {
        var orders = await _repository.GetAllAsync();

        if (buyerId.HasValue)
            orders = orders.Where(o => o.BuyerId == buyerId.Value);

        if (date.HasValue)
            orders = orders.Where(o => o.OrderDate.Date == date.Value.Date);

        var result = new List<OrderWithTotalDto>();
        foreach (var order in orders)
        {
            result.Add(await MapToDtoWithConversionAsync(order));
        }

        return result;
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _repository.GetByIdAsync(id);
        return order is null ? null : MapToDto(order);
    }

    public async Task<OrderDto> AddAsync(CreateOrderDto dto)
    {
        var order = new Order
        {
            BuyerId = dto.BuyerId,
            OrderDate = dto.OrderDate,
            Items = [.. dto.Items.Select(i => new OrderItem
            {
                MeatId = i.Meat.Id,
                Price = i.Price,
                Currency = i.Currency
            })]
        };

        await _repository.AddAsync(order);
        var created = await _repository.GetByIdAsync(order.Id);
        return MapToDto(created!);
    }

    public async Task<bool> UpdateAsync(int id, CreateOrderDto dto)
    {
        var order = await _repository.GetByIdAsync(id);
        if (order is null) return false;

        order.BuyerId = dto.BuyerId;
        order.OrderDate = dto.OrderDate;
        order.Items = [.. dto.Items.Select(i => new OrderItem
        {
            MeatId = i.Meat.Id,
            Price = i.Price,
            Currency = i.Currency
        })];

        await _repository.UpdateAsync(order);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _repository.GetByIdAsync(id);
        if (order == null) return false;

        await _repository.DeleteAsync(order);
        return true;
    }

    private OrderDto MapToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            Buyer = new BuyerDto
            {
                Id = order.Buyer.Id,
                Name = order.Buyer.Name
            },
            Items = [.. order.Items.Select(i => new OrderItemDto
            {
                Meat = new MeatDto
                {
                    Id = i.Meat.Id,
                    Name = i.Meat.Name
                },
                Price = i.Price,
                Currency = i.Currency
            })]
        };
    }

    private async Task<OrderWithTotalDto> MapToDtoWithConversionAsync(Order order)
    {
        var dto = MapToDto(order);
        var totalBRL = 0m;

        foreach (var item in order.Items)
        {
            totalBRL += await _converter.ConvertToBRLAsync(item.Currency, item.Price);
        }

        return new OrderWithTotalDto
        {
            Id = dto.Id,
            Buyer = new BuyerDto
            {
                Id = dto.Buyer.Id,
                Name = dto.Buyer.Name
            },
            OrderDate = dto.OrderDate,
            Items = dto.Items,
            TotalInBRL = totalBRL
        };
    }
}
