using Domains.Models;
using Repositories.Repositories.AppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servcies.DbDataServcies
{
    public class SupplierDataService
    {
        private readonly SupplierRepository _repository;

        public SupplierDataService(SupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddSupplier(Supplier value)
        {
            return await _repository.AddAsync(value);
        }

        public async Task<int> DeleteSupplier(Supplier value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            return await _repository.GetAsync();
        }

        public async Task<Supplier> GetSupplierAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Supplier> GetSupplierAsync(Supplier value)
        {
            return await _repository.GetAsync(value);
        }

        public async Task<int> UpdateSupplier(Supplier value)
        {
            return await _repository.UpdateAsync(value);
        }
    }

}
