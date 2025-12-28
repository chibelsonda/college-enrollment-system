namespace CollegeEnrollmentSystem.ViewModels.Students
{
    public class StudentListItemViewModel
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
    }
}
