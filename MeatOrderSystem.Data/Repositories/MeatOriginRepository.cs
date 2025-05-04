using MeatOrderSystem.Data.Context;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class MeatOriginRepository : IMeatOriginRepository
{
    private readonly AppDbContext _context;

    public MeatOriginRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MeatOrigin>> GetAllAsync()
    {
        return await _context.MeatOrigins.ToListAsync();
    }
}