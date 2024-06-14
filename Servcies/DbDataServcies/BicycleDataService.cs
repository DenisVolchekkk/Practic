using Domains.Models;
using Repositories.Repositories.AppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servcies.DbDataServcies
{
    public class BicycleDataService
    {
        private readonly BicycleRepository _repository;

        public BicycleDataService(BicycleRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddBicycle(Bicycle value)
        {
            return await _repository.AddAsync(value);
        }

        public async Task<int> DeleteBicycle(Bicycle value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<List<Bicycle>> GetBicycles()
        {
            return await _repository.GetAsync();
        }

        public async Task<Bicycle> GetBicycleAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Bicycle> GetBicycleAsync(Bicycle value)
        {
            return await _repository.GetAsync(value);
        }

        public async Task<int> UpdateBicycle(Bicycle value)
        {
            return await _repository.UpdateAsync(value);
        }
    }

}
