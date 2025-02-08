using Microsoft.AspNetCore.Identity;

namespace ERPSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
