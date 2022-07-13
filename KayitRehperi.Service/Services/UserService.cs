using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KayitRehperi.Core.DTOs;
using KayitRehperi.Core.Models;
using KayitRehperi.Core.Services;
using AutoMapper.Internal.Mappers;
using KayitRehperi.Service.Mapping;

namespace KayitRehperi.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CustomResponseDto<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new AppUser { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return CustomResponseDto<AppUserDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return CustomResponseDto<AppUserDto>.Success(200,ObjectMapper.Mapper.Map<AppUserDto>(user));
        }

        public async Task<CustomResponseDto<AppUserDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return CustomResponseDto<AppUserDto>.Fail("UserName not found", 404, true);
            }

            return CustomResponseDto<AppUserDto>.Success(200,ObjectMapper.Mapper.Map<AppUserDto>(user));
        }
    }
}