namespace KayitRehperi.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetSingleCustomerByIdWithCustomerActivitiesAsync(int customerId);
        Task<List<object>> GetCountCustomerByCity();
        Task<List<object>> GetCountCustomerByTel();
    }
}
