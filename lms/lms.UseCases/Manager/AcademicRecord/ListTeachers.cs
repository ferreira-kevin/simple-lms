using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Manager.AcademicRecord;

public interface IListTeachers
{
    Task<IEnumerable<TeacherModel>> Execute();
}

public class ListTeachers(ITeacherRepository _teacherRepository) : IListTeachers
{
    public async Task<IEnumerable<TeacherModel>> Execute()
    {
        return await _teacherRepository.GetAllAsync();
    }
}
