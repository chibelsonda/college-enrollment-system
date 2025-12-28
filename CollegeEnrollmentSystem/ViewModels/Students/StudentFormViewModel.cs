using System.ComponentModel.DataAnnotations;

namespace CollegeEnrollmentSystem.ViewModels.Students
{
    public class StudentFormViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }
    }
}
