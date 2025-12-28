using Microsoft.AspNetCore.Identity;

namespace CollegeEnrollmentSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
