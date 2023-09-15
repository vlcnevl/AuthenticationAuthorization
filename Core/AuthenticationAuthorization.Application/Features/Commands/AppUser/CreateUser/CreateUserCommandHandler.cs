using AuthenticationAuthorization.Application.Abstraction.Services;
using AuthenticationAuthorization.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponseDto response = await _userService.CreateAsync(new() 
            {  Email = request.Email,
               Username = request.Username, 
               ConfirmPassword = request.ConfirmPassword, 
               NameSurname = request.NameSurname,
               Password = request.Password
            });
            
            return new() { Message = response.Message, Succeded = response.Succeded };

        }
    }
}
