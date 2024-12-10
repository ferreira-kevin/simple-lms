using lms.Data.Repositories;
using lms.Domain;

namespace lms.UseCases.Manager.AcademicRecord;

public interface IListStudents
{
    Task<IEnumerable<StudentModel>> Execute();
}

public class ListStudents(IStudentRepository _studentRepository) : IListStudents
{
    public async Task<IEnumerable<StudentModel>> Execute()
    {
        return await _studentRepository.GetAllAsync();
    }
}
