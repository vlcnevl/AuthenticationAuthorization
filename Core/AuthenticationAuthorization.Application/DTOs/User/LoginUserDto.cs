using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Application.DTOs.User
{
    public class LoginUserDto
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}
