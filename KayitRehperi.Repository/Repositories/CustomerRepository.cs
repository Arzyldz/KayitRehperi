using Microsoft.EntityFrameworkCore;
using KayitRehperi.Core;
using KayitRehperi.Core.Repositories;

namespace KayitRehperi.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetSingleCustomerByIdWithCustomerActivitiesAsync(int customerId)
        {
            return await _context.Customers.Include(x => x.CustomerActivities).Where(x => x.Id == customerId).SingleOrDefaultAsync();
        }
        
    }
}
