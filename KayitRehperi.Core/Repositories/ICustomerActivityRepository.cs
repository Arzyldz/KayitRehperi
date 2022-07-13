namespace KayitRehperi.Core.Repositories
{
    public interface ICustomerActivityRepository : IGenericRepository<CustomerActivity>
    {
        Task<List<CustomerActivity>> GetCustomerActivitiesWitCategory();


    }
}
