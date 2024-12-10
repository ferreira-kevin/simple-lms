using lms.Domain;

namespace lms.Data.Repositories;

public interface IClassRepository : IRepository<ClassModel>
{
}

public class ClassRepository(LmsDbContext _context) : Repository<ClassModel>(_context), IClassRepository
{

}