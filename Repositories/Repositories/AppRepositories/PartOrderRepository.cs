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
    public class PartOrderRepository : MainRepository, IRepository<PartOrder>
    {
        public PartOrderRepository(BicyclesContext Context) : base(Context)
        {
        }

        public async Task<int> AddAsync(PartOrder value)
        {
            await _context.PartOrders.AddAsync(value);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(PartOrder value)
        {
            _context.PartOrders.Remove(value);
            return await SaveChangesAsync();
        }

        public async Task<List<PartOrder>> GetAsync()
        {
            return await _context.PartOrders.Include(p => p.Bicycle)
            .ToListAsync();
        }

        public async Task<PartOrder> GetAsync(int id)
        {
            return await _context.PartOrders.Include(po => po.Bicycle)
                .ThenInclude(b => b.PartBicycles)
                .ThenInclude(pb => pb.Part)
                .FirstOrDefaultAsync(b => b.BicycleId == id);
        }

        public async Task<PartOrder> GetAsync(PartOrder value)
        {
            return await _context.PartOrders.Include(p => p.Bicycle)
                .FirstOrDefaultAsync(b => b.BicycleId == value.BicycleId);
        }

        public async Task<int> UpdateAsync(PartOrder value)
        {
            _context.PartOrders.Update(value);
            return await SaveChangesAsync();
        }
    }
}
