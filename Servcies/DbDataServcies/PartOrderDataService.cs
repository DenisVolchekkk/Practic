using Domains.Models;
using Repositories.Repositories.AppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servcies.DbDataServcies
{
    public class PartOrderDataService
    {
        private readonly PartOrderRepository _repository;

        public PartOrderDataService(PartOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddSupplier(PartOrder value)
        {
            return await _repository.AddAsync(value);
        }

        public async Task<int> DeleteSupplier(PartOrder value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<List<PartOrder>> GetSuppliers()
        {
            return await _repository.GetAsync();
        }

        public async Task<PartOrder> GetSupplierAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<PartOrder> GetSupplierAsync(PartOrder value)
        {
            return await _repository.GetAsync(value);
        }

        public async Task<int> UpdateSupplier(PartOrder value)
        {
            return await _repository.UpdateAsync(value);
        }
    }
}
