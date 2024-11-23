using lms.Domain;
using Microsoft.EntityFrameworkCore;

namespace lms.Data.Repositories;

public interface IQuestionAnswerRepository : IRepository<QuestionAnswerModel>
{
    Task SetQuestionAsync(Guid assignmnetAttemptId, Guid questionId, Guid optionId);
    Task<List<QuestionAnswerModel>> ListQuestionAnswers(Guid assignmnetAttemptId);
}

public class QuestionAnswerRepository(LmsDbContext _context) : Repository<QuestionAnswerModel>(_context), IQuestionAnswerRepository
{
    public async Task SetQuestionAsync(Guid assignmnetAttemptId, Guid questionId, Guid optionId)
    {
        var questionAnswer = await _context.QuestionAnswers
            .FirstOrDefaultAsync(qa => qa.AssignmentAttemptId == assignmnetAttemptId && qa.QuestionId == questionId);

        if (questionAnswer is not null)
        {
            questionAnswer.Inactivate();
            _context.QuestionAnswers.Update(questionAnswer);
        }

        _context.QuestionAnswers.Add(new(Guid.NewGuid(), assignmnetAttemptId, questionId, optionId, true, DateTime.Now, DateTime.Now));
    }

    public async Task<List<QuestionAnswerModel>> ListQuestionAnswers(Guid assignmnetAttemptId)
    {
        return await _context.QuestionAnswers.Where(qa => qa.AssignmentAttemptId == assignmnetAttemptId).ToListAsync();
    }
}
