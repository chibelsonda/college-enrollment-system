using System.ComponentModel.DataAnnotations;

namespace CollegeEnrollmentSystem.DTOs.Service.Students
{
    public class StudentCreateDto
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Range(1, 120)]
        public required int Age { get; set; }
    }

    public class StudentUpdateDto
    {
        [Required]
        public required Guid Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Range(1, 120)]
        public required int Age { get; set; }
    }

    public class StudentResponseDto
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required int Age { get; set; }
    }
}
