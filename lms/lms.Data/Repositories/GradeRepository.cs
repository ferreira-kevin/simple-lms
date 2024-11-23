using lms.Domain;
using Microsoft.EntityFrameworkCore;

namespace lms.Data.Repositories;

public interface IGradeRepository : IRepository<GradingModel>
{
}

public class GradeRepository(LmsDbContext _context) : Repository<GradingModel>(_context), IGradeRepository
{
    public async Task<List<GradingModel>> GetAssignmentWithQuestionsAsync(Guid studentId)
    {
        return await _context.Grades
            .Where(g => g.StudentId == studentId).ToListAsync();
    }
}