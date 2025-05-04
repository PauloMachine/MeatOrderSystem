using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using MeatOrderSystem.Service.Interfaces;

namespace MeatOrderSystem.Service.Services;

public class MeatService : IMeatService
{
    private readonly IMeatRepository _repository;

    public MeatService(IMeatRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MeatDto>> GetAllAsync()
    {
        var meats = await _repository.GetAllAsync();
        return meats.Select(m => new MeatDto
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            Origin = new OriginDto
            {
                Id = m.Origin?.Id ?? 0,
                Name = m.Origin?.Name ?? string.Empty
            }
        });
    }

    public async Task<MeatDto?> GetByIdAsync(int id)
    {
        var meat = await _repository.GetByIdAsync(id);
        return meat is null ? null : new MeatDto
        {
            Id = meat.Id,
            Name = meat.Name,
            Description = meat.Description,
            Origin = new OriginDto
            {
                Id = meat.Origin?.Id ?? 0,
                Name = meat.Origin?.Name ?? string.Empty
            }
        };
    }

    public async Task<MeatDto> AddAsync(CreateMeatDto dto)
    {
        var meat = new Meat
        {
            Name = dto.Name,
            Description = dto.Description,
            OriginId = dto.OriginId
        };

        await _repository.AddAsync(meat);

        var createdMeat = await _repository.GetByIdAsync(meat.Id);

        return new MeatDto
        {
            Id = createdMeat.Id,
            Name = createdMeat.Name,
            Description = createdMeat.Description,
            Origin = new OriginDto
            {
                Id = createdMeat.Origin?.Id ?? 0,
                Name = createdMeat.Origin?.Name ?? string.Empty
            }
        };
    }

    public async Task<MeatDto?> UpdateAsync(int id, CreateMeatDto dto)
    {
        var meat = await _repository.GetByIdAsync(id);
        if (meat is null) return null;

        meat.Name = dto.Name;
        meat.Description = dto.Description;
        meat.OriginId = dto.OriginId;

        await _repository.UpdateAsync(meat);

        var updatedMeat = await _repository.GetByIdAsync(id);

        return new MeatDto
        {
            Id = updatedMeat.Id,
            Name = updatedMeat.Name,
            Description = updatedMeat.Description,
            Origin = new OriginDto
            {
                Id = updatedMeat.Origin?.Id ?? 0,
                Name = updatedMeat.Origin?.Name ?? string.Empty
            }
        };
    }

    public async Task<(bool Success, string? Error)> DeleteAsync(int id)
    {
        var meat = await _repository.GetByIdAsync(id);
        if (meat == null)
            return (false, "Meat not found");

        if (await _repository.HasOrdersAsync(id))
            return (false, "Cannot delete: There are orders linked to this meat.");

        await _repository.DeleteAsync(meat);
        return (true, null);
    }
}
