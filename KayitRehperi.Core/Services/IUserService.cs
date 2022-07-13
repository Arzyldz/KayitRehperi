using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KayitRehperi.Core.DTOs;

namespace KayitRehperi.Core.Services
{
    public interface IUserService
    {
        Task<CustomResponseDto<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<CustomResponseDto<AppUserDto>> GetUserByNameAsync(string userName);
    }
}