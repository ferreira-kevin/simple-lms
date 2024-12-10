using lms.Domain;

namespace lms.Data.Repositories;
public interface ITeacherRepository : IRepository<TeacherModel>
{
}

public class TeacherRepository(LmsDbContext _context) : Repository<TeacherModel>(_context), ITeacherRepository
{
}

