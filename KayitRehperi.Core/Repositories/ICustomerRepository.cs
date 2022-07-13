namespace KayitRehperi.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetSingleCustomerByIdWithCustomerActivitiesAsync(int customerId);
    }
}
