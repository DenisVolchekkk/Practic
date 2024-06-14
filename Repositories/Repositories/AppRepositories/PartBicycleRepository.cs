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
    public class PartBicycleRepository : MainRepository, IRepository<PartBicycle>
    {
        public PartBicycleRepository(BicyclesContext context) : base(context)
        {
        }

        public async Task<int> AddAsync(PartBicycle value)
        {
            await _context.PartBicycles.AddAsync(value);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(PartBicycle value)
        {
            _context.PartBicycles.Remove(value);
            return await SaveChangesAsync();
        }

        public async Task<List<PartBicycle>> GetAsync()
        {
            return await _context.PartBicycles
                .Include(pb => pb.Bicycle)
                .Include(pb => pb.Part)
                .ToListAsync();
        }

        public async Task<PartBicycle> GetAsync(int id)
        {
            return await _context.PartBicycles
                .Include(pb => pb.Bicycle)
                .Include(pb => pb.Part)
                .FirstOrDefaultAsync(pb => pb.PartBicycleId == id);
        }

        public async Task<PartBicycle> GetAsync(PartBicycle value)
        {
            return await _context.PartBicycles
                .Include(pb => pb.Bicycle)
                .Include(pb => pb.Part)
                .FirstOrDefaultAsync(pb => pb.PartId == value.PartId && pb.BicycleId == value.BicycleId);
        }

        public async Task<int> UpdateAsync(PartBicycle value)
        {
            _context.PartBicycles.Update(value);
            return await SaveChangesAsync();
        }
    }

}
