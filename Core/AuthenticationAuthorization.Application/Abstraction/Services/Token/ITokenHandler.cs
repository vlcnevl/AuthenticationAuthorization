using AuthenticationAuthorization.Domain.Entities.Identity;
using AuthenticationAuthorization.Application.DTOs;

namespace AuthenticationAuthorization.Application.Abstraction.Services.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second,AppUser user); 
    }
}
