namespace lms.Domain;
public class TeacherModel
{
    public Guid Id { get; set; }

    public UserModel? User { get; set; }
    public List<CourseModel> Courses { get; set; } = [];

    public TeacherModel() { }
    public TeacherModel(string fullName, string email, string identity, string phone, string hashedPassword, DateOnly birthDate)
    {
        Id = Guid.NewGuid();
        User = new UserModel(Id, fullName, email, identity, phone, hashedPassword, [Role.Teacher], birthDate, DateTime.UtcNow, DateTime.UtcNow);
    }
}
