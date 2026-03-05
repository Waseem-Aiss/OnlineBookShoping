using Microsoft.AspNetCore.Identity;

namespace OnlineBookShoping.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
