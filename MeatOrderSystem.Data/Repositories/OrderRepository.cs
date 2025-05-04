using MeatOrderSystem.Data.Context;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeatOrderSystem.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Buyer).ThenInclude(b => b.City).ThenInclude(c => c.State)
            .Include(o => o.Items).ThenInclude(i => i.Meat).ThenInclude(m => m.Origin)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Buyer).ThenInclude(b => b.City).ThenInclude(c => c.State)
            .Include(o => o.Items).ThenInclude(i => i.Meat).ThenInclude(m => m.Origin)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}
