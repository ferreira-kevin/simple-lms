using lms.Domain;

namespace lms.Data.Repositories;

public interface IStudentRepository : IRepository<StudentModel>
{
}

public class StudentRepository(LmsDbContext _context) : Repository<StudentModel>(_context), IStudentRepository
{
}