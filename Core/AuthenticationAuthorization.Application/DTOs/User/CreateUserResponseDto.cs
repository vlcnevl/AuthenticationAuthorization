using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Application.DTOs.User
{
    public class CreateUserResponseDto
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }
    }
}
