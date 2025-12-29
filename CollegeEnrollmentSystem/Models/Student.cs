using System.ComponentModel.DataAnnotations;


namespace CollegeEnrollmentSystem.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public required int Age { get; set; }
    }
}