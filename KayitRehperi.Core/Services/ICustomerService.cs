using KayitRehperi.Core.DTOs;

namespace KayitRehperi.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
         Task<CustomResponseDto<CustomerWithCustomerActivityDto>> GetSingleCustomerByIdWithCustomerActivitiesAsync(int customerId);
         Task<CustomResponseDto<List<CustomerDto>>> GetCountCustomerByCity();
         Task<CustomResponseDto<List<CustomerDto>>> GetCountCustomerByTel();
    }
}
