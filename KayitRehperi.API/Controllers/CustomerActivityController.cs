using AutoMapper;
using KayitRehperi.API.Controllers;
using KayitRehperi.API.Filters;
using KayitRehperi.Core;
using KayitRehperi.Core.DTOs;
using KayitRehperi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KayitRehperi.API.Controllers
{
    public class CustomerActivityController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerActivityService _service;

        public CustomerActivityController(IMapper mapper, ICustomerActivityService productService)
        {

            _mapper = mapper;
            _service = productService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerWithCustomerActivity()
        {

            return CreateActionResult(await _service.GetCustomerWithCustomerActivityDto());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<CutomerActivityDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<CutomerActivityDto>>.Success(200, productsDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<CustomerActivity>))]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<CutomerActivityDto>(product);
            return CreateActionResult(CustomResponseDto<CutomerActivityDto>.Success(200, productsDto));
        }



        [HttpPost]
        public async Task<IActionResult> Save(CutomerActivityDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<CustomerActivity>(productDto));
            var productsDto = _mapper.Map<CutomerActivityDto>(product);
            return CreateActionResult(CustomResponseDto<CutomerActivityDto>.Success(201, productsDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(CutomerActivityDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<CustomerActivity>(productDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
