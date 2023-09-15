using AuthenticationAuthorization.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Application.Features.Commands.AppUser.LoginUser
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
          var token = await _authService.LoginAsync(new() { EmailOrUsername = request.EmailOrUsername, Password = request.Password },60);
          
            return new() { Token = token };
        
        }
    }
}
