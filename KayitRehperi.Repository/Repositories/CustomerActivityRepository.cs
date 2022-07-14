using KayitRehperi.Core;
using KayitRehperi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KayitRehperi.Repository.Repositories
{
    public class CustomerActivityRepository : GenericRepository<CustomerActivity>, ICustomerActivityRepository
    {
        public CustomerActivityRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public Task<List<CustomerActivity>> GetCustomerActivitiesWitCustomer()
        {
            throw new NotImplementedException();
        }

        public async Task<List<object>> GetMaxTop5CustomerActivity()
        {
            //	Haftalık olarak en fazla tiraci faliyete sahip ilk 5  müşteri  email yoluyla raporlanacak. 
            var result = _context.CustomerActivities
                            .GroupBy(a => a.CustomerId)
                            .Select(g => new 
                            {
                                CustomerId = g.Key,
                                Count = g.Count(),
                                Name = g.Max(x => x.ActivityName)
                            }).OrderByDescending(x => x.Count).Take(5).ToListAsync<object>();


            return await result;
        }
    }
}
