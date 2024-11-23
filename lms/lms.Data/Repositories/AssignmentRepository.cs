using lms.Domain;
using Microsoft.EntityFrameworkCore;

namespace lms.Data.Repositories;

public interface IAssignmentRepository : IRepository<AssignmentModel>
{
    Task<AssignmentModel?> GetAssignmentWithQuestionsAsync(Guid assignmentId);
}

public class AssignmentRepository(LmsDbContext _context) : Repository<AssignmentModel>(_context), IAssignmentRepository
{
    public async Task<AssignmentModel?> GetAssignmentWithQuestionsAsync(Guid assignmentId)
    {
        return await _context.Assignments
            .Include(a => a.Questions)
            .ThenInclude(q => q.Options)
            .FirstOrDefaultAsync(a => a.Id == assignmentId);
    }
}