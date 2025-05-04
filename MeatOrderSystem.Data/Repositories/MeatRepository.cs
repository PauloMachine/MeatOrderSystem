using MeatOrderSystem.Data.Context;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeatOrderSystem.Data.Repositories;

public class MeatRepository : IMeatRepository
{
    private readonly AppDbContext _context;

    public MeatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Meat>> GetAllAsync()
    {
        return await _context.Meats.Include(m => m.Origin).ToListAsync();
    }

    public async Task<Meat?> GetByIdAsync(int id)
    {
        return await _context.Meats.Include(m => m.Origin).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Meat meat)
    {
        _context.Meats.Add(meat);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Meat meat)
    {
        _context.Meats.Update(meat);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Meat meat)
    {
        _context.Meats.Remove(meat);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasOrdersAsync(int meatId)
    {
        return await _context.OrderItems.AnyAsync(oi => oi.MeatId == meatId);
    }
}
