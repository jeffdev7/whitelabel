using Microsoft.AspNetCore.Identity;

namespace app.whitelabel.Entities.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreationDate { get; set; }
    }
}