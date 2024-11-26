namespace lms.Domain
{
    public class StudentModel
    {
        public Guid Id { get; set; }
        public required string EnrollmentNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public UserModel? User { get; set; }
    }
}
