using AuthenticationAuthorization.Application.Abstraction.Services;
using AuthenticationAuthorization.Application.Abstraction.Services.Token;
using AuthenticationAuthorization.Application.DTOs;
using AuthenticationAuthorization.Application.DTOs.User;
using AuthenticationAuthorization.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Persistance.Services
{
    public class AuthService : IAuthService
    {
        readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;

        public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<Token> LoginAsync(LoginUserDto userDto,int tokenLifeTime)
        {
           AppUser? user = await _userManager.FindByNameAsync(userDto.EmailOrUsername);
           if (user == null)
            {
               user = await _userManager.FindByEmailAsync(userDto.EmailOrUsername);
            }
            if (user == null)
                throw new Exception("Kullanıcı adı veya şifre hatalı");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user,userDto.Password,false);

            if(result.Succeeded)
            {
               Token token = _tokenHandler.CreateAccessToken(tokenLifeTime, user);
                return token;
            }
            throw new Exception("Kullanıcı adı veya şifre hatalı");

        }
    }
}
