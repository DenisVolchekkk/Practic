using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(int id);

        Task<T> GetAsync(T value);

        Task<List<T>> GetAsync();

        Task<int> AddAsync(T value);

        Task<int> UpdateAsync(T value);

        Task<int> DeleteAsync(T value);
    }
}
