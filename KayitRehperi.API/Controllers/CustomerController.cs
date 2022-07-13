using AutoMapper;
using KayitRehperi.Core.DTOs;
using KayitRehperi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayitRehperi.API.Controllers
{
    [Authorize(Roles="Admin")]
    public class CustomerController : CustomBaseController
    {
        private readonly ICustomerService _cutomerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService cutomerService, IMapper mapper)
        {
            _cutomerService = cutomerService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var customers = await _cutomerService.GetAllAsync();

            var customerDto = _mapper.Map<List<CustomerDto>>(customers.ToList());

            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200,customerDto));
        
        }


        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int customerId)
        {
            
            return CreateActionResult(await _cutomerService.GetSingleCustomerByIdWithCustomerActivitiesAsync(customerId));
          
        }

    }
}
