namespace lms.Domain;

public class CourseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ModuleModel> Modules { get; set; } = [];
    public ClassModel? Class { get; set; }
    public TeacherModel? Teacher { get; set; }
    public List<StudentModel> Students { get; set; } = [];
    public List<AssignmentModel> Assignments { get; set; } = [];
    public CourseModel()
    {
        Id = Guid.NewGuid();
    }
}
