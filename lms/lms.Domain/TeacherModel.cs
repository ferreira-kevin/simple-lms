namespace lms.Domain;
public class TeacherModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public UserModel? User { get; set; }
    public List<CourseModel> Courses { get; set; } = [];
}
