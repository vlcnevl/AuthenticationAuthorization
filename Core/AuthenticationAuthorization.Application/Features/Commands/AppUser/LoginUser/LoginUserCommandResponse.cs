using AuthenticationAuthorization.Application.DTOs;

namespace AuthenticationAuthorization.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
}