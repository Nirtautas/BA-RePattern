using Microsoft.AspNetCore.Identity;

namespace RePattern.Data.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public required DateTime CreationDate { get; set; }
    }
}
