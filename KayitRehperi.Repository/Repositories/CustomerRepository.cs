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
        public async Task<List<object>> GetCountCustomerByTel()
        {
            //	Aynı telefon numarasına sahip ama farklı isim ile kaydedilmiş müşterilerin tesbit edilmesi.
            var result = _context.Customers
                     .GroupBy(a => a.Tel)
                     .Select(g => new 
                     {
                         Tel = g.Key,
                         Count = g.Count(),
                         Name = g.Max(x => x.Name),
                         SurName = g.Max(x => x.SurName),
                     }).ToListAsync<object>();


            return await result;
        }
        public async Task<List<object>> GetCountCustomerByCity()
        {
            //	Aylık olarak email yoluyla  hangi şehirde kaç tane müşteri olduğu raporlancak.
            var result =_context.Customers
                     .GroupBy(a => a.City)
                     .Select(g => new { g.Key,
                         Count = g.Count(),
                         Name = g.Max(x => x.Name),
                         SurName = g.Max(x => x.SurName),
                         EMail = g.Max(x => x.EMail),
                         Tel = g.Max(x => x.Tel)
                     }).ToListAsync<object>();


            return await result;
        }

        public async Task<Customer> GetSingleCustomerByIdWithCustomerActivitiesAsync(int customerId)
        {
            return await _context.Customers.Include(x => x.CustomerActivities).Where(x => x.Id == customerId).SingleOrDefaultAsync();
        }

    }
}
