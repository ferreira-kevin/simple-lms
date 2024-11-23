using lms.Domain;
using Microsoft.EntityFrameworkCore;

namespace lms.Data.Repositories;

public interface IAssignmentAttemptRepository : IRepository<AssignmentAttemptModel>
{
    Task<AssignmentAttemptModel?> GetCurrentAssignmentAttemptAsync(Guid assignmentId, Guid studentId);
}

public class AssignmentAttemptRepository(LmsDbContext _context) : Repository<AssignmentAttemptModel>(_context), IAssignmentAttemptRepository
{
    public async Task<AssignmentAttemptModel?> GetCurrentAssignmentAttemptAsync(Guid assignmentId, Guid studentId)
    {
        return await _context.AssignmentAttempts
            .Include(a => a.Assignment)
            .ThenInclude(a => a.Questions)
            .ThenInclude(q => q.Options)
            .Include(a => a.QuestionAnswers)
            .OrderBy(a => a.Attempt)
            .LastOrDefaultAsync(a => a.AssignmentId == assignmentId);
    }
}