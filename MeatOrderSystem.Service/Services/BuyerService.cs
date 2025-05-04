using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using MeatOrderSystem.Service.Interfaces;

namespace MeatOrderSystem.Service.Services;

public class BuyerService : IBuyerService
{
    private readonly IBuyerRepository _repository;

    public BuyerService(IBuyerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BuyerDto>> GetAllAsync()
    {
        var buyers = await _repository.GetAllAsync();
        return buyers.Select(b => new BuyerDto
        {
            Id = b.Id,
            Name = b.Name,
            Document = b.Document,
            City = new CityDto
            {
                Id = b.City.Id,
                Name = b.City.Name,
                State = new StateDto
                {
                    Id = b.City.State.Id,
                    Name = b.City.State.Name
                }
            }
        });
    }

    public async Task<BuyerDto?> GetByIdAsync(int id)
    {
        var b = await _repository.GetByIdAsync(id);
        if (b is null) return null;

        return new BuyerDto
        {
            Id = b.Id,
            Name = b.Name,
            Document = b.Document,
            City = new CityDto
            {
                Id = b.City.Id,
                Name = b.City.Name,
                State = new StateDto
                {
                    Id = b.City.State.Id,
                    Name = b.City.State.Name
                }
            }
        };
    }

    public async Task<BuyerDto> AddAsync(CreateBuyerDto dto)
    {
        var buyer = new Buyer
        {
            Name = dto.Name,
            Document = dto.Document,
            CityId = dto.CityId
        };

        await _repository.AddAsync(buyer);

        var created = await _repository.GetByIdAsync(buyer.Id);

        return new BuyerDto
        {
            Id = created.Id,
            Name = created.Name,
            Document = created.Document,
            City = new CityDto
            {
                Id = created.City.Id,
                Name = created.City.Name,
                State = new StateDto
                {
                    Id = created.City.State.Id,
                    Name = created.City.State.Name
                }
            }
        };
    }

    public async Task<BuyerDto?> UpdateAsync(int id, CreateBuyerDto dto)
    {
        var buyer = await _repository.GetByIdAsync(id);
        if (buyer is null) return null;

        buyer.Name = dto.Name;
        buyer.Document = dto.Document;
        buyer.CityId = dto.CityId;

        await _repository.UpdateAsync(buyer);

        var updated = await _repository.GetByIdAsync(id);

        return new BuyerDto
        {
            Id = updated.Id,
            Name = updated.Name,
            Document = updated.Document,
            City = new CityDto
            {
                Id = updated.City.Id,
                Name = updated.City.Name,
                State = new StateDto
                {
                    Id = updated.City.State.Id,
                    Name = updated.City.State.Name
                }
            }
        };
    }

    public async Task<(bool Success, string? Error)> DeleteAsync(int id)
    {
        var buyer = await _repository.GetByIdAsync(id);
        if (buyer == null)
            return (false, "Buyer not found");

        if (await _repository.HasOrdersAsync(id))
            return (false, "Cannot delete: There are orders linked to this buyer.");

        await _repository.DeleteAsync(buyer);
        return (true, null);
    }
}
