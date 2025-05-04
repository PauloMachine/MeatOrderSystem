using MeatOrderSystem.Application.DTOs;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Service.Interfaces;

namespace MeatOrderSystem.Service.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _repository;

    public CityService(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CityDto>> GetAllAsync()
    {
        var cities = await _repository.GetAllAsync();
        return cities.Select(c => new CityDto
        {
            Id = c.Id,
            Name = c.Name,
            State = new StateDto
            {
                Id = c.State.Id,
                Name = c.State.Name
            }
        });
    }

    public async Task<IEnumerable<CityDto>> GetByStateIdAsync(int stateId)
    {
        var cities = await _repository.GetByStateIdAsync(stateId);

        return cities.Select(c => new CityDto
        {
            Id = c.Id,
            Name = c.Name,
            State = new StateDto
            {
                Id = c.State.Id,
                Name = c.State.Name
            }
        });
    }
}