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
    public class SupplierRepository : MainRepository, IRepository<Supplier>
    {
        public SupplierRepository(BicyclesContext context) : base(context)
        {
        }

        public async Task<int> AddAsync(Supplier value)
        {
            await _context.Suppliers.AddAsync(value);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Supplier value)
        {
            _context.Suppliers.Remove(value);
            return await SaveChangesAsync();
        }

        public async Task<List<Supplier>> GetAsync()
        {
            return await _context.Suppliers
                .Include(s => s.SupplierType)
                .Include(s => s.Parts)
                .ToListAsync();
        }

        public async Task<Supplier> GetAsync(int id)
        {
            return await _context.Suppliers
                .Include(s => s.SupplierType)
                .Include(s => s.Parts)
                .FirstOrDefaultAsync(s => s.SupplierId == id);
        }

        public async Task<Supplier> GetAsync(Supplier value)
        {
            return await _context.Suppliers
                .Include(s => s.SupplierType)
                .Include(s => s.Parts)
                .FirstOrDefaultAsync(s => s.SupplierName == value.SupplierName
                                       && s.ContactInfo == value.ContactInfo
                                       && s.Address == value.Address);
        }

        public async Task<int> UpdateAsync(Supplier value)
        {
            _context.Suppliers.Update(value);
            return await SaveChangesAsync();
        }
    }

}
