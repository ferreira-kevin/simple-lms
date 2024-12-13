using lms.Domain.Enums;

namespace lms.Domain;

public class ClassModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ClassType Type { get; set; }
    public int StudentCount => Students?.Count ?? 0;
    public List<CourseModel> Courses { get; set; } = [];
    public List<StudentModel> Students { get; set; } = [];

    public ClassModel() { }
}
