﻿using KayitRehperi.Core.DTOs;

namespace KayitRehperi.Core.Services
{
    public interface ICustomerActivityService : IService<CustomerActivity>
    {
        Task<CustomResponseDto<List<CustomerWithCustomerActivityDto>> >GetCustomerWithCustomerActivityDto();


    }
}
