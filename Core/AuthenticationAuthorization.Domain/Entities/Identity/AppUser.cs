
using Microsoft.AspNetCore.Identity;

namespace AuthenticationAuthorization.Domain.Entities.Identity;

    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
    }

