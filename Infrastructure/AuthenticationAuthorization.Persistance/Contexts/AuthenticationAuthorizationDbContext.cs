using AuthenticationAuthorization.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAuthorization.Persistance.Contexts
{
    public class AuthenticationAuthorizationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AuthenticationAuthorizationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
