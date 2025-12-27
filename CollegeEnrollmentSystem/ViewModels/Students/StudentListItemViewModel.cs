namespace CollegeEnrollmentSystem.ViewModels.Students
{
    public class StudentListItemViewModel
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }
    }
}
