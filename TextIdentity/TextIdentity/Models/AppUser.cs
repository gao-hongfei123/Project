using Microsoft.AspNetCore.Identity;

namespace TextIdentity.Models
{
    public class AppUser:IdentityUser
    {
        public string City { get; set; }
    }
}
