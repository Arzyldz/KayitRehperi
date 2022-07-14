namespace KayitRehperi.Core.Repositories
{
    public interface ICustomerActivityRepository : IGenericRepository<CustomerActivity>
    {
        Task<List<CustomerActivity>> GetCustomerActivitiesWitCustomer();

        Task<List<object>> GetMaxTop5CustomerActivity();
    }
}
