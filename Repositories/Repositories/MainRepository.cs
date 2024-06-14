using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class MainRepository
    {
        protected readonly BicyclesContext _context;

        public MainRepository(BicyclesContext orderContext)
        {
            _context = orderContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }


}
