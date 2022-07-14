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
            var customer = await _customerRepository.GetSingleCustomerByIdWithCustomerActivitiesAsync(customerId);

            var categoryDto = _mapper.Map<CustomerWithCustomerActivityDto>(customer);

            return CustomResponseDto<CustomerWithCustomerActivityDto>.Success(200, categoryDto);
        }
        public async Task<CustomResponseDto<List<CustomerDto>>> GetCountCustomerByCity()
        {
            List<object> customers = await _customerRepository.GetCountCustomerByCity();


            var customersDto = _mapper.Map<List<CustomerDto>>(customers);
            return CustomResponseDto<List<CustomerDto>>.Success(200, customersDto);
        }
        public async Task<CustomResponseDto<List<CustomerDto>>> GetCountCustomerByTel()
        {
            List<object> customers = await _customerRepository.GetCountCustomerByTel();


            var customersDto = _mapper.Map<List<CustomerDto>>(customers);
            return CustomResponseDto<List<CustomerDto>>.Success(200, customersDto);
        }
    }
}
