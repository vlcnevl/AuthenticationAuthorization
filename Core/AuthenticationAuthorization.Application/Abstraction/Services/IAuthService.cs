using AuthenticationAuthorization.Application.DTOs;
using AuthenticationAuthorization.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Application.Abstraction.Services
{
    public interface IAuthService
    {
        Task<Application.DTOs.Token> LoginAsync(LoginUserDto userDto,int tokenLifeTime);
    }
}
