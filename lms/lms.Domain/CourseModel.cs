namespace lms.Domain;

public class CourseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ModuleModel> Modules { get; set; } = new();

    public CourseModel()
    {
        Id = Guid.NewGuid();
    }
}
