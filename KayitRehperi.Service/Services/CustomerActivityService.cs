﻿using AutoMapper;
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
            var products = await _customerActivityRepository.GetCustomerActivitiesWitCustomer();

            var productsDto = _mapper.Map<List<CustomerWithCustomerActivityDto>>(products);
            return CustomResponseDto<List<CustomerWithCustomerActivityDto>>.Success(200, productsDto);
        }
        public async Task<CustomResponseDto<List<CutomerActivityDto>>> GetMaxTop5CustomerActivity()
        {
            List<object> customersActivities = await _customerActivityRepository.GetMaxTop5CustomerActivity();


            var customersDto = _mapper.Map<List<CutomerActivityDto>>(customersActivities);
            return CustomResponseDto<List<CutomerActivityDto>>.Success(200, customersDto);
        }

    }
}
