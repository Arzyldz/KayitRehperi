using KayitRehperi.Core.DTOs;

namespace KayitRehperi.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        public Task<CustomResponseDto<CustomerWithCustomerActivityDto>> GetSingleCustomerByIdWithCustomerActivitiesAsync(int customerId);

    }
}
