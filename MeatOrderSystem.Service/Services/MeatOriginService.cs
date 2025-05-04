using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Service.Interfaces;

namespace MeatOrderSystem.Service.Services;

public class MeatOriginService : IMeatOriginService
{
    private readonly IMeatOriginRepository _repository;

    public MeatOriginService(IMeatOriginRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MeatOriginDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();

        return entities.Select(o => new MeatOriginDto
        {
            Id = o.Id,
            Name = o.Name
        });
    }
}
