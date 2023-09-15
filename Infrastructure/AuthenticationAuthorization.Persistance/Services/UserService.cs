using AuthenticationAuthorization.Application.Abstraction.Services;
using AuthenticationAuthorization.Application.DTOs.User;
using AuthenticationAuthorization.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Persistance.Services;

    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto createUserDto)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = createUserDto.Email,
                UserName = createUserDto.Username,
                NameSurname = createUserDto.NameSurname,
            },createUserDto.Password);

            CreateUserResponseDto response = new() { Succeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı Başarıyla Oluşturuldu.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}<br>";

            return response;

        }
    }

