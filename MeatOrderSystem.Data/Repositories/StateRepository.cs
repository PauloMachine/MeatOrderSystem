using MeatOrderSystem.Data.Context;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeatOrderSystem.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;

        public StateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await _context.States
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
