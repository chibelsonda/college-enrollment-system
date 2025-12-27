namespace CollegeEnrollmentSystem.ViewModels.Students
{
    public class StudentDetailsViewModel
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required int Age { get; set; }
    }
}
