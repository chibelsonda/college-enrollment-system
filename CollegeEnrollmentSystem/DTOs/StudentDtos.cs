using System.ComponentModel.DataAnnotations;

namespace CollegeEnrollmentSystem.DTOs
{
    public class StudentCreateDto
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        public required int Age { get; set; }
    }

    public class StudentUpdateDto : StudentCreateDto
    {
        public Guid Id { get; set; }
    }

    public class StudentResponseDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required int Age { get; set; }
    }
}
