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
    public class PartRepository : MainRepository, IRepository<Part>
    {
        public PartRepository(BicyclesContext context) : base(context)
        {
        }

        public async Task<int> AddAsync(Part value)
        {
            await _context.Parts.AddAsync(value);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Part value)
        {
            _context.Parts.Remove(value);
            return await SaveChangesAsync();
        }

        public async Task<List<Part>> GetAsync()
        {
            return await _context.Parts
                .Include(p => p.Supplier)
                .Include(p => p.PartBicycles)
                .ToListAsync();
        }

        public async Task<Part> GetAsync(int id)
        {
            return await _context.Parts
                .Include(p => p.Supplier)
                .Include(p => p.PartBicycles)
                .FirstOrDefaultAsync(p => p.PartId == id);
        }

        public async Task<Part> GetAsync(Part value)
        {
            return await _context.Parts
                .Include(p => p.Supplier)
                .Include(p => p.PartBicycles)
                .FirstOrDefaultAsync(p => p.PartName == value.PartName && p.PartDescription == value.PartDescription);
        }

        public async Task<int> UpdateAsync(Part value)
        {
            _context.Parts.Update(value);
            return await SaveChangesAsync();
        }
    }

}
