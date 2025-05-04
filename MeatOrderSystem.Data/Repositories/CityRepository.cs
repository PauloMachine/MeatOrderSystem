using MeatOrderSystem.Data.Context;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeatOrderSystem.Data.Repositories;

public class CityRepository : ICityRepository
{
    private readonly AppDbContext _context;

    public CityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Cities
            .Include(c => c.State)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<City>> GetByStateIdAsync(int stateId)
    {
        return await _context.Cities
            .Include(c => c.State)
            .Where(c => c.StateId == stateId)
            .ToListAsync();
    }
}