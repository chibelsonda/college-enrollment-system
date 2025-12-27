using System.ComponentModel.DataAnnotations;

namespace CollegeEnrollmentSystem.ViewModels.Students
{
    public class StudentFormViewModel
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

        [Range(1, 120)]
        public required int Age { get; set; }
    }
}
