using AutoMapper;
using KayitRehperi.Core;
using KayitRehperi.Core.DTOs;
using KayitRehperi.Core.Repositories;
using KayitRehperi.Core.Services;
using KayitRehperi.Core.UnitOfWorks;

namespace KayitRehperi.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomResponseDto<CustomerWithCustomerActivityDto>> GetSingleCustomerByIdWithCustomerActivitiesAsync(int customerId)
        {
            var category = await _customerRepository.GetSingleCustomerByIdWithCustomerActivitiesAsync(customerId);

            var categoryDto = _mapper.Map<CustomerWithCustomerActivityDto>(category);

            return CustomResponseDto<CustomerWithCustomerActivityDto>.Success(200, categoryDto);
        }
    }
}
