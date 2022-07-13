using AutoMapper;
using KayitRehperi.Core;
using KayitRehperi.Core.DTOs;
using KayitRehperi.Core.Repositories;
using KayitRehperi.Core.Services;
using KayitRehperi.Core.UnitOfWorks;

namespace KayitRehperi.Service.Services
{
    public class CustomerActivityService : Service<CustomerActivity>, ICustomerActivityService
    {
        private readonly ICustomerActivityRepository _customerActivityRepository;
        private readonly IMapper _mapper;

        public CustomerActivityService(IGenericRepository<CustomerActivity> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerActivityRepository customerRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _customerActivityRepository = customerRepository;
        }

        public async Task<CustomResponseDto<List<CustomerWithCustomerActivityDto>>> GetCustomerWithCustomerActivityDto()
        {
            var products = await _customerActivityRepository.GetCustomerActivitiesWitCategory();

            var productsDto = _mapper.Map<List<CustomerWithCustomerActivityDto>>(products);
            return CustomResponseDto<List<CustomerWithCustomerActivityDto>>.Success(200, productsDto);
        }

    }
}
