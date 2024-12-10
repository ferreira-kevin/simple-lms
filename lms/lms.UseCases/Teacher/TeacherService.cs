using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Teacher;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly ICourseRepository _courseRepository;

    public TeacherService(ITeacherRepository teacherRepository, ICourseRepository courseRepository)
    {
        _teacherRepository = teacherRepository;
        _courseRepository = courseRepository;
    }

    public async Task<TeacherModel> GetByIdAsync(Guid id)
    {
        return await _teacherRepository.GetByIdAsync(id);
    }
}

public interface ITeacherService
{
    Task<TeacherModel> GetByIdAsync(Guid id);
}
