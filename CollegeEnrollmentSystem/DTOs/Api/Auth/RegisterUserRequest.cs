using System.ComponentModel.DataAnnotations;

namespace CollegeEnrollmentSystem.DTOs.Api.Auth
{
    public class RegisterUserRequest
    {
        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, MinLength(8)]
        public required string Password { get; set; }
    }
}
