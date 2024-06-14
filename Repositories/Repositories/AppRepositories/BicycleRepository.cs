using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.AppRepositories
{
    public class BicycleRepository : MainRepository, IRepository<Bicycle>
    {
        public BicycleRepository(BicyclesContext orderContext) : base(orderContext)
        {
        }

        public async Task<int> AddAsync(Bicycle value)
        {
            await _context.Bicycles.AddAsync(value);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Bicycle value)
        {
            _context.Bicycles.Remove(value);
            return await SaveChangesAsync();
        }

        public async Task<List<Bicycle>> GetAsync()
        {
            return await _context.Bicycles
                .Include(b => b.PartBicycles)
                .Include(b => b.PartOrders)
                .ToListAsync();
        }

        public async Task<Bicycle> GetAsync(int id)
        {
            return await _context.Bicycles
                .Include(b => b.PartBicycles)
                .Include(b => b.PartOrders)
                .FirstOrDefaultAsync(b => b.BicycleId == id);
        }

        public async Task<Bicycle> GetAsync(Bicycle value)
        {
            return await _context.Bicycles
                .Include(b => b.PartBicycles)
                .Include(b => b.PartOrders)
                .FirstOrDefaultAsync(b => b.ModelName == value.ModelName);
        }

        public async Task<int> UpdateAsync(Bicycle value)
        {
            _context.Bicycles.Update(value);
            return await SaveChangesAsync();
        }
    }

}
