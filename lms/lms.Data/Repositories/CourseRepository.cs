using lms.Domain;

namespace lms.Data.Repositories;

public interface ICourseRepository : IRepository<CourseModel>
{
}

public class CourseRepository(LmsDbContext _context) : Repository<CourseModel>(_context), ICourseRepository
{
}