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
    public class SupplierTypeRepository : MainRepository, IRepository<SupplierType>
    {
        public SupplierTypeRepository(BicyclesContext context) : base(context)
        {
        }

        public async Task<int> AddAsync(SupplierType value)
        {
            await _context.SupplierTypes.AddAsync(value);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(SupplierType value)
        {
            _context.SupplierTypes.Remove(value);
            return await SaveChangesAsync();
        }

        public async Task<List<SupplierType>> GetAsync()
        {
            return await _context.SupplierTypes
                .Include(st => st.Suppliers)
                .ToListAsync();
        }

        public async Task<SupplierType> GetAsync(int id)
        {
            return await _context.SupplierTypes
                .Include(st => st.Suppliers)
                .FirstOrDefaultAsync(st => st.SupplierTypeId == id);
        }

        public async Task<SupplierType> GetAsync(SupplierType value)
        {
            return await _context.SupplierTypes
                .Include(st => st.Suppliers)
                .FirstOrDefaultAsync(st => st.SupplierTypeName == value.SupplierTypeName);
        }

        public async Task<int> UpdateAsync(SupplierType value)
        {
            _context.SupplierTypes.Update(value);
            return await SaveChangesAsync();
        }
    }
}
