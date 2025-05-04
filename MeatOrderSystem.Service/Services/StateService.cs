using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Service.Interfaces;

namespace MeatOrderSystem.Service.Services;

public class StateService : IStateService
{
    private readonly IStateRepository _repository;

    public StateService(IStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StateDto>> GetAllAsync()
    {
        var states = await _repository.GetAllAsync();

        return states.Select(s => new StateDto
        {
            Id = s.Id,
            Name = s.Name
        });
    }
}
