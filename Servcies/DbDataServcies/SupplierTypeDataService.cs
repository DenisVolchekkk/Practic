using Domains.Models;
using Repositories.Repositories.AppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servcies.DbDataServcies
{
    public class SupplierTypeDataService
    {
        private readonly SupplierTypeRepository _repository;

        public SupplierTypeDataService(SupplierTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddSupplierType(SupplierType value)
        {
            return await _repository.AddAsync(value);
        }

        public async Task<int> DeleteSupplierType(SupplierType value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<List<SupplierType>> GetSupplierTypes()
        {
            return await _repository.GetAsync();
        }

        public async Task<SupplierType> GetSupplierTypeAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<SupplierType> GetSupplierTypeAsync(SupplierType value)
        {
            return await _repository.GetAsync(value);
        }

        public async Task<int> UpdateSupplierType(SupplierType value)
        {
            return await _repository.UpdateAsync(value);
        }
    }

}
