using lms.Domain;

namespace lms.Data.Repositories;

public interface IUserRepository : IRepository<UserModel>
{
}

public class UserRepository(LmsDbContext _context) : Repository<UserModel>(_context), IUserRepository
{
}