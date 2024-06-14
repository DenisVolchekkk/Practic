using Domains.Models;
using Repositories.Repositories.AppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servcies.DbDataServcies
{
    public class PartBicycleDataService
    {
        private readonly PartBicycleRepository _repository;

        public PartBicycleDataService(PartBicycleRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddPartBicycle(PartBicycle value)
        {
            return await _repository.AddAsync(value);
        }

        public async Task<int> DeletePartBicycle(PartBicycle value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<List<PartBicycle>> GetPartBicycles()
        {
            return await _repository.GetAsync();
        }

        public async Task<PartBicycle> GetPartBicycleAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<PartBicycle> GetPartBicycleAsync(PartBicycle value)
        {
            return await _repository.GetAsync(value);
        }

        public async Task<int> UpdatePartBicycle(PartBicycle value)
        {
            return await _repository.UpdateAsync(value);
        }
    }

}
