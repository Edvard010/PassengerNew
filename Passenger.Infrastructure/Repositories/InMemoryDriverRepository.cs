using Passenger.Core.Repositories;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static ISet<Driver> _drivers = new HashSet<Driver>();
        public async Task AddAsync(Driver driver)
        {
            await Task.FromResult(_drivers.Add(driver));
        }

        public async Task<Driver> GetAsync(Guid userid)
            => await Task.FromResult(_drivers.Single(x => x.UserId == userid));

        public async Task<IEnumerable<Driver>> GetAllAsync()
            => await Task.FromResult(_drivers);

        public async Task UpdateAsync(Driver driver)
        {
            await Task.CompletedTask;
        }
    }
}
