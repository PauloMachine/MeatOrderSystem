using MeatOrderSystem.Data.Context;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeatOrderSystem.Data.Repositories;

public class BuyerRepository : IBuyerRepository
{
    private readonly AppDbContext _context;

    public BuyerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Buyer>> GetAllAsync()
    {
        return await _context.Buyers.Include(b => b.City).ThenInclude(c => c.State).ToListAsync();
    }

    public async Task<Buyer?> GetByIdAsync(int id)
    {
        return await _context.Buyers.Include(b => b.City).ThenInclude(c => c.State)
                                    .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Buyer buyer)
    {
        _context.Buyers.Add(buyer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Buyer buyer)
    {
        _context.Buyers.Update(buyer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Buyer buyer)
    {
        _context.Buyers.Remove(buyer);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasOrdersAsync(int buyerId)
    {
        return await _context.Orders.AnyAsync(o => o.BuyerId == buyerId);
    }
}
