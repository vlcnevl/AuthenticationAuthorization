﻿using AuthenticationAuthorization.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Application.Abstraction.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateAsync(CreateUserDto createUserDto);
    }
}
