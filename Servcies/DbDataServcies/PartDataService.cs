using Domains.Models;
using Repositories.Repositories.AppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servcies.DbDataServcies
{
    public class PartDataService
    {
        private readonly PartRepository _repository;

        public PartDataService(PartRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddPart(Part value)
        {
            return await _repository.AddAsync(value);
        }

        public async Task<int> DeletePart(Part value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<List<Part>> GetParts()
        {
            return await _repository.GetAsync();
        }

        public async Task<Part> GetPartAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Part> GetPartAsync(Part value)
        {
            return await _repository.GetAsync(value);
        }

        public async Task<int> UpdatePart(Part value)
        {
            return await _repository.UpdateAsync(value);
        }
    }

}
