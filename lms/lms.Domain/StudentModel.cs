using Microsoft.EntityFrameworkCore;

namespace lms.Domain;

[Index(nameof(EnrollmentNumber), IsUnique = true)]
public class StudentModel
{
    public Guid Id { get; set; }
    public string EnrollmentNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public UserModel? User { get; set; }

    public StudentModel() { }

    public StudentModel(Guid id, string enrollmentNumber, DateTime enrollmentDate, UserModel user)
    {
        Id = id;
        EnrollmentNumber = enrollmentNumber;
        EnrollmentDate = enrollmentDate;
        User = user;
    }

    public StudentModel(string enrollmentNumber, string fullName, string email, string identity, string phone, string hashedPassword, DateOnly birthDate)
    {
        Id = Guid.NewGuid();
        EnrollmentNumber = enrollmentNumber;
        EnrollmentDate = DateTime.UtcNow;

        User = new UserModel(Id, fullName, email, identity, phone, hashedPassword, [Role.Student], birthDate, DateTime.UtcNow, DateTime.UtcNow);
    }

    public StudentModel(Guid id, string enrollmentNumber, string fullName, string email, string identity, string phone, string hashedPassword, DateOnly birthDate)
    {
        Id = id;
        EnrollmentNumber = enrollmentNumber;
        EnrollmentDate = DateTime.UtcNow;

        User = new UserModel(Id, fullName, email, identity, phone, hashedPassword, [Role.Student], birthDate, DateTime.UtcNow, DateTime.UtcNow);
    }
}